using System;
using System.IO;
using System.Linq;
using System.Text;

namespace FrequencyDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var fileText = String.Empty;

            try
            {   
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    fileText = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Файл не может быть прочитан. Ошибка:");
                Console.WriteLine(e.Message);
                Console.ReadKey();
                return;    
            }

            var outputPath = path + ".output.txt";

            var textUnifier = new TextUnifier(fileText);
            var words = textUnifier.GetStringWords();

            var dictionary = new CountDictionary(words);    
            var sortedDict = dictionary.GetDictionary().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            using (var sw = new StreamWriter(outputPath))
            {
                foreach (var var in sortedDict)
                {
                    sw.WriteLine(var.Key + "\t" + var.Value);
                }
            }
        }
    }
}
