using System.Linq;
using System.Text.RegularExpressions;

namespace FrequencyDictionary
{
    public class TextUnifier
    {
        private string _unifiedString { get; set; }

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
        }

        public string GetUnifyString()
        {
            return _unifiedString;                  
        }

        public string[] GetStringWords()
        {
            return _unifiedString.Split(' ').Where(x => x.Length > 0).ToArray();
        } 
    }
}