using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace P3_WordCound
{
    class WordCound
    {
        static void Main(string[] args)
        {
            using (StreamReader wordsReader = new StreamReader(@"..\..\WordCountWords.txt"))
            {
                using (StreamReader textReader = new StreamReader(@"..\..\WordCountText.txt"))
                {
                    using (StreamWriter writer = new StreamWriter(@"..\..\WordCountResult.txt"))
                    {
                        string text = textReader.ReadToEnd().ToLower();
                        var result = new SortedDictionary<string,int>();
                        string word=wordsReader.ReadLine();
                        while (word!= null)
                        {
                            string pattern = string.Format(@"\b{0}\b", word.ToLower());
                            MatchCollection match = Regex.Matches(text, pattern);
                            result.Add(word,match.Count);
                            word = wordsReader.ReadLine();
                        }
                        foreach (var match in result.Reverse())
                        {
                            writer.WriteLine("{1} - {0}", match.Value, match.Key);
                            Console.WriteLine("{1} - {0}", match.Value, match.Key);
                        }
                    }
                }
            }
        }
    }
}
