using System;
using System.IO;
using System.Collections.Generic;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за чтение аудиофайла и извлечение сэмплов
    /// </summary>
    public class SampleParser
    {
        #region Конструктор класса

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="filePath">Путь к входному файлу</param>
        public SampleParser(string filePath)
        {
            Filename = filePath;
        }

        #endregion

        #region Методы для обработки аудиофайла

        /// <summary>
        /// Загружает в память указанный файл
        /// </summary>
        public void LoadFile()
        {
            try
            {
                using (FileStream file = File.OpenRead(Filename))
                {
                    if (file.CanRead)
                    {
                        int file_len = Convert.ToInt32(file.Length);

                        byte[] tmpAudioBinBuffer = new byte[file_len];

                        file.Read(tmpAudioBinBuffer, 0, file_len);

                        AudiofileBinData = tmpAudioBinBuffer;
                    }

                    else
                        throw new Exception("Невозможно открыть аудиофайл");
                }
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
        }

        #region Чтение и обработка заголовка

        /// <summary>
        /// Запускает обработку заголовка
        /// </summary>
        public void ProcessingChunk()
        {
            GetChunk();
            AnalyseChunk();
            GetData();
        }

        /// <summary>
        /// Получает заголовок из двоичных данных
        /// </summary>
        private unsafe void GetChunk()
        {
            try
            {
                for (int i = 0; i < 44; i++)
                    Chunk.binary_data[i] = AudiofileBinData[i];
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
        }

        /// <summary>
        /// Читает полученный заголовок и получает данные о файле
        /// </summary>
        private unsafe void AnalyseChunk()
        {
            try
            {
                // Получаем количество каналов в аудиофайле

                byte[] tmpNoCarray = new byte[2] { Chunk.binary_data[22], Chunk.binary_data[23] };
                
                ReadOnlySpan<byte> numOfChannelsSpan = new ReadOnlySpan<byte>(tmpNoCarray);
                
                Chunk.numOfChannels = BitConverter.ToInt16(numOfChannelsSpan);

                // Получаем частоту дискретизации

                byte[] tmpSRarray = new byte[4] { Chunk.binary_data[24], Chunk.binary_data[25], Chunk.binary_data[26], Chunk.binary_data[27] };
                
                ReadOnlySpan<byte> sampleRateSpan = new ReadOnlySpan<byte>(tmpSRarray);
                
                Chunk.sampleRate = BitConverter.ToUInt16(sampleRateSpan);

                // Получаем глубину кодирования

                byte[] tmpPCMarray = new byte[2] { Chunk.binary_data[34], Chunk.binary_data[35] };

                ReadOnlySpan<byte> pcmSpan = new ReadOnlySpan<byte>(tmpPCMarray);

                Chunk.pcm = BitConverter.ToInt16(pcmSpan);
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
        }

        /// <summary>
        /// Записывает область данных, отсекая заголовок
        /// </summary>
        private void GetData()
        {
            try
            {
                byte[] tmpBinData = new byte[AudiofileBinData.Length - 44];

                for (int i = 44; i < AudiofileBinData.Length; i++)
                    tmpBinData[i - 44] = AudiofileBinData[i];

                AudioBinDataWithoutChunk = tmpBinData;
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
        }

        #endregion

        #region Получение сэмплов

        /// <summary>
        /// Метод класса, отвечающий за извлечение сэмплов из аудиофайла с глубиной кодирования 16 бит
        /// </summary>
        /// <returns>Массив сэмплов</returns>
        public Int16[] Get16bitSamplesFromFile()
        {
            try
            {
                List<Int16> tmpSample = new List<Int16>();

                for (int i = 0; i < AudioBinDataWithoutChunk.Length; i += 2)
                {
                    byte[] tmp = new byte[2] { AudioBinDataWithoutChunk[i], AudioBinDataWithoutChunk[i + 1] };

                    ReadOnlySpan<byte> Span = new ReadOnlySpan<byte>(tmp);

                    tmpSample.Add(BitConverter.ToInt16(Span));
                }

                Samples_16_bit = tmpSample.ToArray();
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return null;
            }

            return Samples_16_bit;
        }

        #endregion

        #endregion

        #region Методы для цифрового кодирования сигнала и записи нового аудиофайла

        /// <summary>
        /// Преобразует 16-битные сэмплы в байты и записывает в новый файл со старым заголовком
        /// </summary>
        /// <param name="path">Путь к создаваемому файлу</param>
        /// <param name="sampleArray">Массив сэмплов</param>
        public unsafe void Write16BitSamples(string path, Int16[] sampleArray)
        {
            List<byte> all_new_audiofile = new List<byte>();

            for (int i = 0; i < 44; i++)
            {
                all_new_audiofile.Add(Chunk.binary_data[i]);
            }

            for (int i = 0; i < sampleArray.Length; i++)
            {
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[0]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[1]);
            }

            using (FileStream fileStream = File.Create(path))
            {
                fileStream.Write(all_new_audiofile.ToArray(), 0, all_new_audiofile.Count);
            }

            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nФайл успешно преобразован!\n");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else
                ErrorShow.Print("Что-то пошло не так: файл не был создан по непонятной причине");
        }

        /// <summary>
        /// Преобразует 24-битные сэмплы в байты и записывает в новый файл со старым заголовком
        /// </summary>
        /// <param name="path">Путь к создаваемому файлу</param>
        /// <param name="sampleArray">Массив сэмплов</param>
        public unsafe void Write24BitSamples(string path, double[] sampleArray)
        {
            List<byte> all_new_audiofile = new List<byte>();

            for (int i = 0; i < 44; i++)
            {
                all_new_audiofile.Add(Chunk.binary_data[i]);
            }

            for (int i = 0; i < sampleArray.Length; i++)
            {
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[0]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[1]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[2]);
            }

            using (FileStream fileStream = File.Create(path))
            {
                fileStream.Write(all_new_audiofile.ToArray(), 0, all_new_audiofile.Count);
            }

            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nФайл успешно преобразован!\n");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else
                ErrorShow.Print("Что-то пошло не так: файл не был создан по непонятной причине");
        }

        /// <summary>
        /// Преобразует 32-битные сэмплы в байты и записывает в новый файл со старым заголовком
        /// </summary>
        /// <param name="path">Путь к создаваемому файлу</param>
        /// <param name="sampleArray">Массив сэмплов</param>
        public unsafe void Write32BitSamples(string path, double[] sampleArray)
        {
            List<byte> all_new_audiofile = new List<byte>();

            for (int i = 0; i < 44; i++)
            {
                all_new_audiofile.Add(Chunk.binary_data[i]);
            }

            for (int i = 0; i < sampleArray.Length; i++)
            {
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[0]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[1]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[2]);
                all_new_audiofile.Add(BitConverter.GetBytes(sampleArray[i])[3]);
            }

            using (FileStream fileStream = File.Create(path))
            {
                fileStream.Write(all_new_audiofile.ToArray(), 0, all_new_audiofile.Count);
            }

            if (File.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("\nФайл успешно преобразован!\n");

                Console.ForegroundColor = ConsoleColor.Gray;
            }

            else
                ErrorShow.Print("Что-то пошло не так: файл не был создан по непонятной причине");
        }

        #endregion

        #region Поля класса

        /// <summary>
        /// Имя преобразуемого файла
        /// </summary>
        private string Filename;

        /// <summary>
        /// Сюда загружаются все двоичные данные входного аудиофайла. Дальше программа работает с этим массивом.
        /// </summary>
        private byte[] AudiofileBinData;

        /// <summary>
        /// Область данных аудиофайла, без заголовка
        /// </summary>
        private byte[] AudioBinDataWithoutChunk;

        /// <summary>
        /// Здесь хранится полученный массив сэмплов аудиофайла
        /// c разрядностью (глубиной кодирования) 16 бит
        /// </summary>
        private Int16[] Samples_16_bit;

        /// <summary>
        /// Cтруктура, содержащая заголовок аудиофайла и информацию о нём
        /// </summary>
        public Structures.WavChunk Chunk;

        #endregion
    }
}
