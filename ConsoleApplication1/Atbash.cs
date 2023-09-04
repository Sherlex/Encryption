using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    public class Atbash : ICipher
    {
        private string Reverse(string input_data)
        {
            var reversed_text = string.Empty;
            foreach (var s in input_data)
            {
                reversed_text = s + reversed_text;
            }
            return reversed_text;
        }

        public string Decode(string input, string option)
        {
            input = input.ToLower();
            var decoded_text = string.Empty;
            var cipher = Reverse(option); 
            for (var i = 0; i < input.Length; i++)
            {
                var index = option.IndexOf(input[i]);
                if (index >= 0)
                {
                    decoded_text += cipher[index].ToString();
                }
            }
            return decoded_text;
        }

        public string Encode(string input, string option)
        {
            input = input.ToLower();
            var encoded_text = string.Empty;
            var cipher = Reverse(option);
            for (var i = 0; i < input.Length; i++)
            {
                var index = cipher.IndexOf(input[i]);
                if (index >= 0)
                {
                    encoded_text += option[index].ToString();
                }
            }
            return encoded_text;
        }
    }
}