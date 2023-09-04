using System;
using System.IO;
using System.Linq;
using System.Text;

namespace lr2
{
    public class WorkWithFiles
    {
        public static void SaveFile(string data)
        {
            while (true)
            {
                Console.WriteLine("\nCохранить данные?\n1 - Да\n2 - Нет\n");
                int flag = 0;
                string save_str = Console.ReadLine();
                if (Checks.SubMenu(save_str))
                {
                    var save = int.Parse(save_str);
                    switch (save)
                    {
                        case (int)Checks.OptionsSubMenu.Yes:
                            while (true)
                            {
                                Console.WriteLine("\nВведите путь для сохранения: ");
                                string path = Console.ReadLine();
                                if (!File.Exists(path))
                                {
                                    if (IsSavingPathOk(path))
                                    {
                                        File.Create(path).Close();
                                        SaveData(data, path);
                                        break;
                                    }
                                }
                                else
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("\nФайл существует! Хотите перезаписать? \n1 - Да\n2 - Нет\n");
                                        string rewrite_str = Console.ReadLine();
                                        if (Checks.SubMenu(rewrite_str))
                                        {
                                            var rewrite = int.Parse(rewrite_str);
                                            switch (rewrite)
                                            {
                                                case (int)Checks.OptionsSubMenu.Yes:
                                                    File.WriteAllText(path, String.Empty);
                                                    SaveData(data, path);
                                                    flag = 1;
                                                    break;
                                                case (int)Checks.OptionsSubMenu.No:
                                                    break;
                                            }
                                            break;
                                        }

                                    }
                                    if (flag == 1)
                                        break;
                                }
                            }
                            break;

                        case (int)Checks.OptionsSubMenu.No:
                            break;
                    }
                    break;
                }
            }
        }

        private static void SaveData(string data, string path)
        {
            StreamWriter file = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.Unicode);
            file.WriteLine(data);
            file.Close();
            file.Dispose();
            Console.WriteLine("Файл успешно сохранён! ");
        }

        //Получаем данные из файла
        public static string DataFromFile()
        {
            for (;;)
            {
                Console.WriteLine("\nВведите путь к файлу: \n");
                string path = Console.ReadLine();
                string data = String.Empty;
                if (WorkWithFiles.IsFilePathOk(path))
                {

                    data = File.ReadAllText(path, Encoding.Unicode);
                    var size = new System.IO.FileInfo(path).Length;
                    if (size == 0)
                    {
                        Console.WriteLine("\nФайл пустой! Попробуйте снова. \n");
                    }
                    else
                        return data;
                }
                
            }
           
        }

        public static bool IsFilePathOk(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Некорректный путь! Попробуйте снова.\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsSavingPathOk(string path)
        {
            try
            {
                File.Create(path).Close();
                File.Delete(path);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Попробуйте снова.");
                return false;
            }
        }
    }
}