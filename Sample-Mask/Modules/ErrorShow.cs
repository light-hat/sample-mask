using System;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за вывод ошибок на экран
    /// </summary>
    public static class ErrorShow
    {
        /// <summary>
        /// Метод класса, непосредственно выводящий ошибку на экран
        /// </summary>
        /// <param name="Message">Сообщение об ошибке</param>
        /// <param name="StackTrace">Трассировка стэка. Необязательный параметр.</param>
        /// <param name="Source">Источник. Необязательный параметр.</param>
        public static void Print(string Message, string StackTrace = null, string Source = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\n--- Ошибка! ---\n");
            Console.WriteLine("Что произошло: " + Message);

            if (Source != null)
                Console.WriteLine("\nИсточник: " + Source);

            if (StackTrace != null)
                Console.WriteLine("\nТрассировка стека:\n" + StackTrace);

            Console.WriteLine("\n--- Конец сообщения об ошибке ---\n");

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
