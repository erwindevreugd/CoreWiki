using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreWiki.Extensibility.TheChapel
{
    public class ProfanityFilter
    {
        private readonly char[] PuctuationMarks = new char[]
        {
            ' ', '.', ',', ';', ':', '"', '?', '!', '[', ']', '{', '}', '(', ')', '<', '>',
            '`', '\'', '|', '\\', '/', '-', '_', '=', '+', '~', '@','#','$','%','^','&','*'
        };

        private const string StartTag = "<code>";
        private const string EndTag = "</code>";

        public string Remove(string content, IEnumerable<string> blockedWords)
        {
            var blocked = blockedWords as string[] ?? blockedWords.ToArray();
            var lines = content.Split(Environment.NewLine);
            var sb = new StringBuilder();

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                var filteredLine = FilterLine(line, blocked);

                if (index != lines.Length - 1)
                {
                    sb.AppendLine(filteredLine);
                }
                else
                {
                    sb.Append(filteredLine);
                }
            }

            return sb.ToString();
        }

        private string FilterLine(string line, string[] blockedWords)
        {
            var words = line.Split(' ');
            var sb = new StringBuilder();

            for (var index = 0; index < words.Length; index++)
            {
                var word = words[index];
                var result = CheckWord(word, blockedWords);

                sb.Append(index != words.Length - 1 ? $"{result} " : result);
            }

            return sb.ToString();
        }

        private string CheckWord(string word, string[] blockedWords)
        {
            var wordNoPunctuation = word.Trim(PuctuationMarks);
            if (!blockedWords.Contains(wordNoPunctuation, StringComparer.InvariantCultureIgnoreCase)) return word;

            var wrappedWord = $"{StartTag}{wordNoPunctuation}{EndTag}";
            var replacement = word.Replace(wordNoPunctuation, wrappedWord);

            return replacement;

        }
    }
}
