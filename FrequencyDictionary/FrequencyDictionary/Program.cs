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
            if (args.Length == 0)
            {
                Console.WriteLine("Передайте текстовый файл в качестве аргумента!");
                Console.ReadKey();
                return;
            }

            var path = args[0]; 
            string fileText;
            try
            {
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    fileText = sr.ReadToEnd();
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);           
                Console.ReadKey();
                return;
            }
            catch (FileNotFoundException fileNotFoundEx)
            {
                Console.WriteLine(fileNotFoundEx.Message);  
                Console.ReadKey();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);              
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
                foreach (var word in sortedDict)
                {
                    sw.WriteLine(word.Key + "\t" + word.Value);
                }
            }
            Console.ReadKey();
        }
    }
}