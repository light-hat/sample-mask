using System;
using System.IO;
using System.Windows.Forms;

namespace Sample_Mask.Modules
{
    /// <summary>
    /// Модуль, отвечающий за интерфейс пользователя.
    /// Отвечает за диалог с пользователем, выполняет те или иные действия, указаные им.
    /// </summary>
    public static class UI
    {
        #region Методы, отвечающие за инициализацию интерфейса и запрос команд

        /// <summary>
        /// Запуск диалога выбора действия
        /// </summary>
        public static void Start()
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine("Sample mask by l1ghth4t");

            while (true)
                AskCommand();
        }

        /// <summary>
        /// Метод класса, непосредственно запрашивающий у пользователя команды
        /// </summary>
        private static void AskCommand()
        {
            int command_number = 0;

            Console.WriteLine("\nПрограмма готова к работе.\nДоступные действия:\n[1] Преобразовать файл, открытие через диалоговое окно\n[2] Преобразовать файл, путь к которому указывается вручную\n[3] Выход\n");
            Console.Write("Выберите действие: ");

            try
            {
                try
                {
                    command_number = Convert.ToInt32(Console.ReadLine()); // Считываем команду, приводим к целому числу
                }

                catch (Exception e)
                {
                    ErrorShow.Print(e.Message, e.StackTrace, e.Source);
                }

                switch (command_number) // Обрабатываем введённый номер команды
                {
                    case 0:
                        break;

                    case 1:
                        Handle.ConvertFileWithDialog(); // Открытие и сохранение файла через диалоговое окно
                        break;

                    case 2:
                        Handle.ConvertFileWithPath(); // Для любителей хардкора) Здесь пути прописываем вручную
                        break;

                    case 3:
                        Handle.NormalExit(); // Выход
                        break;

                    default:
                        throw new Exception("Вы ввели некорректный номер команды. Введённое значение: " + command_number);
                }
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);
            }
        }

        #endregion

        #region Методы, отвечающие за указание пути для открытия/сохранения файла

        /// <summary>
        /// Открывает файл с помощью диалога открытия файла
        /// </summary>
        /// <returns>Путь к преобразуемому файлу</returns>
        public static string OpenFileWithDialog()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog(); // Создаём диалог открытия файла
                openFile.Filter = "WAV|*.wav"; // Устанавливаем фильтр - только WAVE аудиофайлы
                openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Начальная директория поиска - рабочий стол
                openFile.Title = "Выберите преобразуемый аудиофайл"; // Указываем заголовок диалогового окна

                DialogResult openFileResult = openFile.ShowDialog(); // Вызываем диалог

                if (openFileResult == DialogResult.OK) // И обрабатываем его
                    return openFile.FileName;

                else
                    throw new Exception("Что-то пошло не так, либо операция открытия была прервана пользователем");
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return null;
            }
        }

        /// <summary>
        /// Метод, запрашивающий у пользователя путь для сохранения результата преобразования
        /// </summary>
        /// <returns>Путь для сохранения выходного файла</returns>
        public static string SaveFileWithDialog()
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog(); // Создаём диалог сохранения файла
                saveFile.Filter = "WAV|*.wav";
                saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // Начальная директория поиска - рабочий стол
                saveFile.Title = "Сохранение результата преобразования"; // Указываем заголовок диалогового окна

                DialogResult saveFileResult = saveFile.ShowDialog(); // Вызываем диалог

                if (saveFileResult == DialogResult.OK || saveFileResult == DialogResult.Yes) // И обрабатываем
                    return saveFile.FileName;

                else
                    throw new Exception("Что-то пошло не так или операция сохранения была прервана пользователем");
            }

            catch (Exception e)
            {
                ErrorShow.Print(e.Message, e.StackTrace, e.Source);

                return null;
            }
        }

        /// <summary>
        /// Запрашивает у пользователя путь к файлу и проверяет его корректность
        /// </summary>
        /// <returns>Путь к преобразуемому файлу</returns>
        public static string OpenFileAtPath()
        {
            string path_to_open_file;

            Console.Write("Введите путь к открываемому файлу: ");
            path_to_open_file = Console.ReadLine(); // Вводим путь

            // Проверяем на валидность
            if (!File.Exists(path_to_open_file))
                throw new Exception("Вы указали путь в неверном формате, либо указанного файла не существует.");

            else if (Path.GetExtension(path_to_open_file) != ".wav")
                throw new Exception("Вы указали файл с неверным расширением или такой формат аудиофайлов не поддерживается.");

            // Возвращаем
            else
                return path_to_open_file;
        }

        /// <summary>
        /// Запрашивает у пользователя путь к файлу, который получится в результате преобразования входного файла
        /// </summary>
        /// <returns>Путь для сохранения выходного файла</returns>
        public static string SaveFileAtPath()
        {
            string path_to_save_file;

            Console.Write("Введите путь к выходному файлу: ");
            path_to_save_file = Console.ReadLine(); // Ввод

            if (!Directory.Exists(Path.GetDirectoryName(path_to_save_file))) // Обработка ошибок
                throw new Exception("Вы сохраняете файл в несуществующей директории.\nПожалуйста, выберите существующую директорию для сохранения файла.");

            else // Возвращаем, если всё ок
                return path_to_save_file;
        }

        #endregion
    }
}
