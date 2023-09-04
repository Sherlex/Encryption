using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lr2
{
    public class Vigener : ICipher
    {
       char[] alphabet = {'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
       'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я'};
        int n = 33;
        public string Encode(string input, string key)
        {
            input = input.ToLower();
            Regex rg = new Regex(@"[^а-яА-Я]");
            string replacement = "";
            input = rg.Replace(input, replacement);
            key = key.ToLower();
            var encoded_text = string.Empty;
            int key_index = 0;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alphabet, symbol) + Array.IndexOf(alphabet, key[key_index])) % n;
                encoded_text += alphabet[c];
                key_index++;
                if ((key_index + 1) == key.Length)
                    key_index = 0;
                }
            return encoded_text;
        }

        public string Decode(string input, string key)
        {
            input = input.ToLower();
            Regex rg = new Regex(@"[^а-яА-Я]");
            string replacement = "";
            input = rg.Replace(input, replacement);
            key = key.ToLower();
            var decoded_text = string.Empty;
            int key_index = 0;
            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(alphabet, symbol) + n - Array.IndexOf(alphabet, key[key_index])) % n;
                decoded_text += alphabet[c];
                key_index++;
                if ((key_index + 1) == key.Length)
                    key_index = 0;
            }
                return decoded_text;
        }
    }
    
}