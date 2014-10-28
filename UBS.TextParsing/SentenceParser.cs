using System.Collections.Generic;
using System.Linq;

namespace UBS.TextParsing
{
    public class SentenceParser
    {
        public IDictionary<string, int> Parse(string sentence)
        {
            Guard.NotNullOrEmpty(() => sentence, sentence);

            var words = sentence.ToLower().SplitIntoWords();

            var wordsCounts = from word in words
                group word by word
                into g
                select new {Word = g.Key, Count = g.Count()};
            
            return wordsCounts.ToDictionary(wc => wc.Word, wc => wc.Count);
        }
    }
}
