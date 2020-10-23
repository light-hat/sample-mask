using System;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Статический класс, реализующий алгоритмы прямого и обратного дискретного преобразования Фурье
    /// </summary>
    public static class DiscreteFourierTransformClass
    {
        /// <summary>
        /// Метод класса, реализующий дискретное преобразование Фурье. Метод реализован для 16-битных сэмлов.
        /// </summary>
        /// <param name="sampleArray">Массив сэмплов</param>
        /// <returns>Спектр аудиосигнала в виде специальной структуры</returns>
        public unsafe static Structures.Spectre DiscreteFourierTransform(Int16[] sampleArray)
        {
            int N = sampleArray.Length;

            Structures.Spectre spectre;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < (N / 2); j++)
                {
                    spectre.a[j] += sampleArray[i] * Math.Cos((2 * Math.PI * j * i) / N);
                    spectre.b[j] += sampleArray[i] * Math.Sin((2 * Math.PI * j * i) / N);
                }

            return spectre;
        }

        /// <summary>
        /// Метод класса, реализующий обратное дискретное преобразование Фурье
        /// На выходе получаем массив 16-битных сэмплов
        /// </summary>
        /// <param name="spectre">Спектр</param>
        /// <param name="N">Длина исходного массива сэмплов</param>
        /// <returns>Выходной массив сэмплов</returns>
        public unsafe static Int16[] ReverseFourierTransform16bit(Structures.Spectre spectre, int N)
        {
            Int16[] sampleArray = new Int16[N];

            for (int i = 0; i < N; i++)
            {
                double ans = 0;

                for (int j = 0; j < (N / 2); j++)
                    ans += (spectre.a[j] * Math.Cos((2 * Math.PI * j * i) / (N))) + (spectre.b[j] * Math.Sin((2 * Math.PI * j * i) / (N)));

                sampleArray[i] = (Int16)((double)((double)ans * (double)((double)2 / (double)N)));
            }

            return sampleArray;
        }
    }
}
