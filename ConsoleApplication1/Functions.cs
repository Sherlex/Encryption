using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lr2
{
    class FillData
    {
        public static string data_keyboard()
        {
            
            Console.WriteLine("\nВведите данные для шифрования: ");
            string data = Console.ReadLine();
            return data;
        }
    }

    public class CipherSelection
    {
        private enum CipherChoice
        {
            Atbash = 1,
            Vigener
        }

        private enum EncodeDecode
        {
            Encode = 1,
            Decode
        }

        public static void cipher_menu(string data)
        {
            while (true)
            {
                Console.WriteLine("\nКакой шифр вы хотите использовать?\n1 - Шифр Атбаш\n2 - Шифр Виженера\n");
                string choice_str = Console.ReadLine();
                if (Checks.SubMenu(choice_str))
                {
                    var choice = int.Parse(choice_str);
                    switch (choice)
                    {
                        case (int)CipherChoice.Atbash:
                            var atbash = new Atbash();
                            while (true)
                            {
                                Console.WriteLine("\nЧто вы хотите сделать?\n1 - Зашифровать\n2 - Расшифровать\n");
                                string move_str = Console.ReadLine();
                                string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
                                if (Checks.SubMenu(move_str))
                                {
                                    var move = int.Parse(move_str);
                                    switch (move)
                                    {
                                        case (int)EncodeDecode.Encode:
                                            Console.WriteLine("\nИсходный текст: {0}", data);
                                            var encryptedstring = atbash.Encode(data, alphabet);
                                            if (encryptedstring == String.Empty)
                                                encryptedstring = data;
                                            Console.WriteLine("Зашифрованный текст: {0}", encryptedstring);
                                            WorkWithFiles.SaveFile(encryptedstring);
                                            break;
                                        case (int)EncodeDecode.Decode:
                                            Console.WriteLine("\nИсходный текст: {0}", data);
                                            var decryptedstring = atbash.Decode(data, alphabet);
                                            if (decryptedstring == String.Empty)
                                                decryptedstring = data;
                                            Console.WriteLine("Дешифрованный текст: {0}", decryptedstring);
                                            WorkWithFiles.SaveFile(decryptedstring);
                                            break;
                                    }
                                    break;
                                }
                            }
                            break;
                        case (int)CipherChoice.Vigener:
                            var vigener = new Vigener();
                            while (true)
                            {
                                Console.WriteLine("\nЧто вы хотите сделать?\n1 - Зашифровать\n2 - Расшифровать\n");
                                string move_str = Console.ReadLine();
                                if (Checks.SubMenu(move_str))
                                {
                                    var move = int.Parse(move_str);
                                    switch (move)
                                    {
                                        case (int)EncodeDecode.Encode:
                                            while (true)
                                            {
                                                Console.WriteLine("Введите ключ (буквенный, содержащий более одного символа): \n");
                                                string key = Console.ReadLine();
                                                if(Checks.IsKeyOk(key))
                                                {
                                                    Console.WriteLine("\nИсходный текст: {0}", data);
                                                    var encryptedstring = vigener.Encode(data, key);
                                                    if (encryptedstring == String.Empty)
                                                        encryptedstring = data;
                                                    Console.WriteLine("Зашифрованный текст: {0}", encryptedstring);
                                                    WorkWithFiles.SaveFile(encryptedstring);
                                                    break;
                                                }
                                            }
                                            break;
                                        case (int)EncodeDecode.Decode:
                                            while (true)
                                            {
                                                Console.WriteLine("\nВведите ключ (буквенный, содержащий более одного символа): \n");
                                                string key = Console.ReadLine();
                                                if (Checks.IsKeyOk(key))
                                                {
                                                    Console.WriteLine("\nИсходный текст: {0}", data);
                                                    var decryptedstring = vigener.Decode(data, key);
                                                    if (decryptedstring == String.Empty)
                                                        decryptedstring = data;
                                                    Console.WriteLine("Дешифрованный текст: {0}", decryptedstring);
                                                    WorkWithFiles.SaveFile(decryptedstring);
                                                    break;
                                                }
                                            }
                                            break;
                                           
                                    }
                                    break;
                                }
                            }
                            break;

                    }
                    break;
                }
            }
        }
    }

    public class Checks
    {
        public enum OptionsSubMenu
        {
            Yes = 1,
            No
        }

        public static bool SubMenu(string decision)
        {
            if (decision != "1" && decision != "2")
            {
                Console.WriteLine("\nНекорректный пункт меню! Попробуйте снова\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool Menu(string menu)
        {
            if (menu != "1" && menu != "2" && menu != "3")
            {
                Console.Clear();
                Console.WriteLine("\nНекорректный пункт меню! Попробуйте снова\n");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsKeyOk(string key)
        {
            while (true)
            {
                Regex rg = new Regex(@"^[а-яА-Я]*$");
                if ((!rg.IsMatch(key)) || (key.Length < 2))
                {
                    Console.WriteLine("Некорректный ключ! Попробуйте снова.");
                    return false;
                }
                return true;
            }
        }
    }
}
