using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab.DotNetQuiz.MostCommonWord
{
    public class LabMostCommonWord
    {
        public static KeyValuePair<string,int> MostCommonWordByLINQ(string inputSentence)
        {
            IList<string> wordsList = inputSentence.Split(' ').ToList();

            var commonWordWithCount = wordsList.GroupBy(x => x).Select(x => new { word = x.Key, count = x.Count() }).OrderByDescending(x=>x.count).FirstOrDefault();

            return new KeyValuePair<string, int>(commonWordWithCount.word, commonWordWithCount.count);
        }

        public static KeyValuePair<string, int> MostCommonWord_Without_LINQ(string inputSentence)
        {
            IDictionary<string, int> commonWords = new Dictionary<string, int>();
            var splitChar = new char[] { ' ', '.' };
            IList<string> wordsList = inputSentence.Split(splitChar,StringSplitOptions.RemoveEmptyEntries).ToList();
       
            foreach (var word in wordsList)
            {
                if (commonWords.ContainsKey(word))
                {
                    commonWords[word] += 1;
                }
                else
                {
                    commonWords[word] = 1;
                }
            }

            var maxValue = commonWords.Max(x => x.Value);

            var commonWordWithCount = commonWords.Where(x => x.Value == maxValue).FirstOrDefault();

            return commonWordWithCount;
        }
    }
}
