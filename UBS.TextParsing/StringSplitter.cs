using System;
using System.Collections.Generic;
using System.Text;

namespace UBS.TextParsing
{
    public static class StringSplitterExtensions
    {
        public static IEnumerable<string> SplitIntoWords(this string str)
        {
            Guard.NotNull(() => str, str);

            var stringList = new List<string>();

            var currentWordSb = new StringBuilder();

            foreach (var chr in str)
            {
                if (Char.IsPunctuation(chr) || Char.IsSeparator(chr) || Char.IsWhiteSpace(chr))
                {
                    AddToList(currentWordSb, stringList);
                    currentWordSb.Clear();
                }
                else
                {
                    currentWordSb.Append(chr);
                }
            }

            AddToList(currentWordSb, stringList);

            return stringList;
        }

        private static void AddToList(StringBuilder stringBuilder, ICollection<string> collection)
        {
            var word = stringBuilder.ToString();
            if(!string.IsNullOrEmpty(word))
                collection.Add(word);
        }
    }
}
