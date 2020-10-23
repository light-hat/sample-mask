namespace Sample_Mask.Modules
{
    /// <summary>
    /// Вспомогательные структуры данных
    /// </summary>
    public static class Structures
    {
        /// <summary>
        /// Структура, хранящая спектр аудиосигнала на участке в 128 сэмплов
        /// </summary>
        public unsafe struct Spectre
        {
            /// <summary>
            /// Коэффициенты разложения по косинусу
            /// </summary>
            public fixed double a[64];

            /// <summary>
            /// Коэффициенты разложения по синусу
            /// </summary>
            public fixed double b[64];
        }

        /// <summary>
        /// Структура, хранящая заголовок аудиофайла формата Wave
        /// </summary>
        public unsafe struct WavChunk
        {
            /// <summary>
            /// Непосредственно двоичные данные заголовка
            /// </summary>
            public fixed byte binary_data[44];

            /// <summary>
            /// Количество каналов в аудиозаписи (моно/стерео)
            /// </summary>
            public int numOfChannels;

            /// <summary>
            /// Частота дискретизации аудиофайла
            /// </summary>
            public int sampleRate;

            /// <summary>
            /// Глубина кодирования
            /// </summary>
            public int pcm;
        }
    }
}
