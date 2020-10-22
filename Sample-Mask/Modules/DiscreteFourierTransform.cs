using System;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Статический класс, реализующий алгоритмы дискретного и обратного преобразования Фурье
    /// </summary>
    public static class DiscreteFourierTransformClass
    {
        /// <summary>
        /// Метод класса, реализующий дискретное преобразование Фурье
        /// </summary>
        /// <param name="sampleArray">Массив сэмплов</param>
        /// <returns>Спектр аудиосигнала в виде специальной структуры</returns>
        public unsafe static Structures.Spectre DiscreteFourierTransform(double[] sampleArray)
        {
            int N = sampleArray.Length;

            Structures.Spectre spectre;

            for (int i = 0; i < N; i++)
                for (int j = 0; j < (N / 2); j++)
                {
                    spectre.a[j] = sampleArray[i] * Math.Cos((2 * Math.PI * j * i) / N);
                    spectre.b[j] = sampleArray[i] * Math.Sin((2 * Math.PI * j * i) / N);
                }

            return spectre;
        }

        /// <summary>
        /// Метод класса, реализующий обратное дискретное преобразование Фурье
        /// </summary>
        /// <param name="spectre">Спектр</param>
        /// <param name="N">Длина исходного массива сэмплов</param>
        /// <returns>Выходной массив сэмплов</returns>
        public unsafe static double[] ReverseFourierTransform(Structures.Spectre spectre, int N)
        {
            double[] sampleArray = new double[N];

            for (int i = 0; i < N; i++)
                for (int j = 0; j < (N / 2); j++)
                    sampleArray[i] = (2 / N) * ((spectre.a[j] * Math.Cos(2 * Math.PI * j * i)) + (spectre.b[j] * Math.Sin(2 * Math.PI * j * i)));

            return sampleArray;
        }
    }
}
