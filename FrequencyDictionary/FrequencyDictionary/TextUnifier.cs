using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace FrequencyDictionary
{
    public class TextUnifier
    {
        private string _unifiedString;

        public TextUnifier(string nonUnifiedString)
        {
            _unifiedString = nonUnifiedString;
            UnifyString();
        }

        private void UnifyString()
        {
            _unifiedString = _unifiedString.ToLower();

            var pattern = "[^à-ÿ ¸ a-z]";
            Regex regex = new Regex(pattern);
            string a = " ";
            _unifiedString = regex.Replace(_unifiedString, a);

            RemoveDuplicateSpaces();
        }

        private void RemoveDuplicateSpaces()
        {
            var space = ' ';
            var lastChar = '\0';
            var strBldr = new StringBuilder();
            foreach (var ch in _unifiedString.ToCharArray())
            {
                if (!(lastChar == space && ch == space))
                {
                    strBldr.Append(ch);
                }
                lastChar = ch;
            }

            if (strBldr[strBldr.Length - 1] == space)
            {
                strBldr.Remove(strBldr.Length - 1, 1);
            }
            _unifiedString = strBldr.ToString();
        }

        public string GetUnifyString()
        {
            return _unifiedString;                  
        }

        public string[] GetStringWords()
        {
            return _unifiedString.Split(' ');
        } 
    }
}