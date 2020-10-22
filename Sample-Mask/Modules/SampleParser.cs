using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за чтение аудиофайла и извлечение сэмплов
    /// </summary>
    public class SampleParser
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="filePath">Путь к входному файлу</param>
        public SampleParser(string filePath)
        {
            Filename = filePath;
        }

        /// <summary>
        /// Метод класса, отвечающий за извлечение сэмплов из аудиофайла
        /// </summary>
        /// <returns>Массив сэмплов</returns>
        public double[] GetSamplesFromFile()
        {
            LoadFile();

            // ...

            return Samples;
        }

        #region Методы для обработки аудиофайла

        /// <summary>
        /// Загружает в память указанный файл
        /// </summary>
        private void LoadFile()
        {
            try
            {
                using (FileStream file = File.OpenRead(Filename))
                {
                    if (file.CanRead)
                    {
                        int file_len = Convert.ToInt32(file.Length);

                        file.Read(AudiofileBinData, 0, file_len);
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

        /// <summary>
        /// Получает заголовок из двоичных данных и читает его
        /// </summary>
        private void GetChunk()
        {
            try
            {
                // ...
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
        }

        private void GetSampleArray()
        {
            try
            {
                // ...
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return;
            }
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
        /// Здесь хранится полученный массив сэмплов аудиофайла
        /// c разрядностью (глубиной кодирования) 8 или 16 бит
        /// </summary>
        private UInt16[] Samples_8_16;

        /// <summary>
        /// Здесь хранится полученный массив сэмплов аудиофайла
        /// с разрядностью 24 или 32 бита
        /// </summary>
        private double[] Samples_24_32;

        /// <summary>
        /// Приватная структура, сохраняющая заголовок аудиофайла
        /// </summary>
        private Structures.WavChunk Chunk;

        #endregion
    }
}
