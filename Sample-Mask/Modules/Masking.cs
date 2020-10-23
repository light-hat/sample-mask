using System;
using System.Collections.Generic;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за преобразование аудиофайла
    /// </summary>
    public class Masking
    {
        /// <summary>
        /// Конструктор класса для PCM 16 бит
        /// </summary>
        /// <param name="SampleArray">Массив сэмплов, считанных из аудиофайла</param>
        public Masking(Int16[] SampleArray)
        {
            InputSampleArray_16bit = SampleArray;
        }

        #region Методы класса

        /// <summary>
        /// Метод класса, выполняющий инверсию спектра
        /// </summary>
        /// <param name="spectre">Спектр в исходном порядке</param>
        /// <param name="lenght">Длина массивов в структуре</param>
        /// <returns>Спектр в обратном порядке</returns>
        private unsafe Structures.Spectre Inverse(Structures.Spectre spectre, int lenght)
        {
            Structures.Spectre ret_spectre;

            try
            {
                for (int i = 0; i < lenght; i++)
                {
                    ret_spectre.a[i] = spectre.a[(lenght - 1) - i];
                    ret_spectre.b[i] = spectre.b[(lenght - 1) - i];
                }
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);
            }

            return ret_spectre;
        }

        /// <summary>
        /// Метод класса, производящий поблочное преобразование массива сэмплов
        /// Преобрахование включает в себя такие операции с каждым блоком:
        /// 1. Преобразование Фурье на участке в 128 сэмплов, который, собственно и является блоком;
        /// 2. Инверсия спектра;
        /// 3. Обратное дискретное преобразование Фурье;
        /// </summary>
        /// <param name="pcm">Глубина кодирования в битах</param>
        public void BlockTransform(int pcm)
        {
            switch (pcm)
            {
                case 16:
                    {
                        List<Int16> tmpFinal = new List<Int16>(); // Создаём временный список для работы

                        for (int i = 0; i < InputSampleArray_16bit.Length; i += 128) // Цикл, обрабатывающий один блок из 128 сэмплов
                        {
                            Int16[] tmp = new Int16[128]; // Создаём массив для данного блока

                            for (int j = 0; j < 128; j++) // И записываем в него сэмплы из общего массива
                                tmp[j] = InputSampleArray_16bit[i + j];

                            Structures.Spectre spectre = DiscreteFourierTransformClass.DiscreteFourierTransform(tmp); // Создаём структуру, хранящую спектр данного блока

                            Structures.Spectre tmpSpectre = Inverse(spectre, 64); // Делаем инверсию полученного спектра, результат храним во временной структуре

                            spectre = tmpSpectre;

                            tmp = DiscreteFourierTransformClass.ReverseFourierTransform16bit(spectre, 128); // Проводим обратное преобразование Фурье

                            tmpFinal.AddRange(tmp); // Получившийся блок записываем во временный список

                            if ((InputSampleArray_16bit.Length - (i + 128)) < 128) // Если размер файла не кратен 128, во избежание переполнения игнорируем последний неполный блок. Оставшиеся несколько сэмплов не будут иметь значения.
                            {
                                break;
                            }
                        }

                        FinalSampleArray16 = tmpFinal.ToArray();
                    }

                    break;
            }
        }

        #endregion

        #region Поля класса

        /// <summary>
        /// Поле класса, хранящее полученный на входе массив сэмплов с pcm 16 бит
        /// </summary>
        private Int16[] InputSampleArray_16bit;

        /// <summary>
        /// Поле класса, хранящее выходной массив 16-битных сэмплов
        /// </summary>
        public Int16[] FinalSampleArray16;

        #endregion
    }
}
