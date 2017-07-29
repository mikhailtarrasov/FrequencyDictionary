using System.Collections.Generic;
using System.Linq;

namespace FrequencyDictionary
{
    public class CountDictionary
    {
        private Dictionary<string, int> Dictionary { get; set; }

        public CountDictionary(IEnumerable<string> words)
        {
            Dictionary = words.GroupBy(x => x).ToDictionary(pair => pair.Key, pair => pair.Count());
        }

        public Dictionary<string, int> GetDictionary()
        {
            return Dictionary;
        }
    }
}