using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal static class RepoValid
    {
        public static string[] Valid(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            string[] words = str.Split(' ');

            if (words.Length < 5)
                return null;

            string[] names = new string[2];
            int counter = 0;

            foreach (string word in words)
            {
                if (char.IsUpper(word[0]))
                {
                    names[counter] = word;
                    counter++;
                    if (counter == 2)
                        break;
                }
            }

            return counter == 2 ? names : null;
        }
    }


}
