using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lr2
{
    interface ICipher
    {
        string Encode(string input, string option);

        string Decode(string input, string option);
    }
}
