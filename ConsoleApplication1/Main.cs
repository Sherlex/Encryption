using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    class Menu
    {
        private enum options
        {
            input_Keyboard = 1,
            input_From_File,
            go_out
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Голова Елена, 474\n" +
        "Данная программа использует шифр Атбаш и шифр Виженера\n" +
        "для преобразования исходного текста на русском языке.\n");
            for (;;)
            {
                Console.WriteLine("Выберите пункт меню:\n" +
                    "1. Ввести данные с клавиатуры\n" +
                    "2. Ввести данные из файла\n" +
                    "3. Выйти из программы\n");
                string menu_str = Console.ReadLine();
                if (Checks.Menu(menu_str))
                {
                    var menu = int.Parse(menu_str);
                    string data;
                    switch (menu)
                    {
                        case (int)options.input_Keyboard:
                            data = FillData.data_keyboard();
                            WorkWithFiles.SaveFile(data);
                            CipherSelection.cipher_menu(data);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)options.input_From_File:
                            data = WorkWithFiles.DataFromFile();
                            Console.WriteLine("\nИсходный текст: {0}", data);
                            CipherSelection.cipher_menu(data);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case (int)options.go_out:
                            return;
                    }

                }
            }
        }
    }
}
