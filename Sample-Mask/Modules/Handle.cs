using System;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, непосредственно исполняющий команды пользователя
    /// </summary>
    public static class Handle
    {
        /// <summary>
        /// Метод, который отвечает за преобразование файла.
        /// При этом файл открывается через диалоговое окно.
        /// </summary>
        public static void ConvertFileWithDialog()
        {
            try
            {
                string filePath = UI.OpenFileWithDialog(); // Открываем файл, записываем путь

                SampleParser sampleParser = new SampleParser(filePath); // Создаём экземпляр парсера сэмплов, в конструктор передаём путь
                
                // Обрабатываем открытый файл
                sampleParser.LoadFile();
                sampleParser.ProcessingChunk();

                Masking masking = null; // Создаём экземпляр класса для преобразования сэмплов

                // Смотрим, сколько каналов. Программа работает только со стерео.
                switch (sampleParser.Chunk.numOfChannels)
                {
                    case 1:
                        break;

                    case 2:
                        throw new Exception("Недопустимое число каналов. Стерео файлы не поддерживаются, только моно.");
                }

                // Проверяем глубину кодирования. Пока работаем только с PCM 16 бит
                switch (sampleParser.Chunk.pcm)
                {
                    case 16:
                        masking = new Masking(sampleParser.Get16bitSamplesFromFile()); // Создаём экземпляр, конструктору передаём сэмплы, которые мы вытащили из файла
                        masking.BlockTransform(16); // Выполняем поблочное преобразование
                        sampleParser.Write16BitSamples(UI.SaveFileWithDialog(), masking.FinalSampleArray16); // Записываем результат в новый файл, результат достаём из публичного метода класса Masking
                        break;

                    default:
                        throw new Exception("Неподдерживаемая глубина кодирования: " + sampleParser.Chunk.pcm + " бит");
                }
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);
            }
        }

        /// <summary>
        /// Метод, который также отвечает за преобразование файла.
        /// При этом путь к файлу указывается вручную.
        /// </summary>
        public static void ConvertFileWithPath()
        {
            try
            {
                string filePath = UI.OpenFileAtPath();

                SampleParser sampleParser = new SampleParser(filePath);
                sampleParser.LoadFile();
                sampleParser.ProcessingChunk();

                Masking masking = null;

                switch (sampleParser.Chunk.numOfChannels)
                {
                    case 1:
                        break;

                    case 2:
                        throw new Exception("Недопустимое число каналов. Стерео файлы не поддерживаются, только моно.");
                }

                switch (sampleParser.Chunk.pcm)
                {
                    case 16:
                        masking = new Masking(sampleParser.Get16bitSamplesFromFile());
                        masking.BlockTransform(16);
                        sampleParser.Write16BitSamples(UI.SaveFileAtPath(), masking.FinalSampleArray16);
                        break;

                    default:
                        throw new Exception("Неподдерживаемая глубина кодирования: " + sampleParser.Chunk.pcm + " бит");
                }
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);
            }
        }

        /// <summary>
        /// Завершение работы программы
        /// </summary>
        public static void NormalExit()
        {
            Environment.Exit(0);
        }
    }
}
