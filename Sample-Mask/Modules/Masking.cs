using System;
using System.Collections.Generic;
using System.Text;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за преобразование аудиофайла
    /// </summary>
    public class Masking
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="SampleArray">Массив сэмплов, считанных из аудиофайла</param>
        public Masking(double[] SampleArray)
        {
            InputSampleArray = SampleArray;
        }

        /// <summary>
        /// Метод класса, выполняющий инверсию спектра
        /// </summary>
        /// <param name="spectre">Спектр в исходном порядке</param>
        /// <param name="lenght">Длина массивов в структуре</param>
        /// <returns>Спектр в обратном порядке</returns>
        private unsafe Structures.Spectre Reverse(Structures.Spectre spectre, int lenght)
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

        #region Поля класса

        /// <summary>
        /// Поле класса, хранящее полученный на входе массив сэмплов
        /// </summary>
        private double[] InputSampleArray;

        /// <summary>
        /// Поле класса, хранящее выходной массив сэмплов
        /// </summary>
        private double[] FinalSampleArray;

        #endregion
    }
}
