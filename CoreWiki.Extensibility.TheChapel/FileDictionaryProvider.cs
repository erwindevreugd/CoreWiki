using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CoreWiki.Extensibility.TheChapel
{
    public class FileDictionaryProvider : IDictionaryProvider
    {
        private readonly string _path;

        public FileDictionaryProvider(string path)
        {
            _path = path;
        }

        public IEnumerable<string> GetDictionary()
        {
            var sw = new Stopwatch();
            sw.Start();
            if(string.IsNullOrWhiteSpace(_path)) throw new ArgumentException("Argument cannot be null or empty", nameof(_path));

            var lines = File.ReadLines(_path);
            sw.Stop();

            var words = lines as string[] ?? lines.ToArray();
            Console.WriteLine($"Loaded {words.Count()} words in {sw.ElapsedMilliseconds}ms from file {_path}");

            return words;
        }
    }
}
