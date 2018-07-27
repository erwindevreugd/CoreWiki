using CoreWiki.Extensibility.TheChapel;
using System;
using System.IO;
using Xunit;

namespace CoreWiki.Test.TheChapel
{
    public class DictionaryProviderTests
    {
        private const string UnknowFile = "unknown_file.txt";
        private const string KnownFile = "bad_words.txt";

        [Fact]
        public void GetDictionary_WithStringEmpty_ThrowsArgumentException()
        {
            var provider = new FileDictionaryProvider(string.Empty);
            var exception = Assert.Throws<ArgumentException>(() => provider.GetDictionary());
        }

        [Fact]
        public void GetDictionary_WithNull_ThrowsArgumentException()
        {
            var provider = new FileDictionaryProvider(null);
            var exception = Assert.Throws<ArgumentException>(() => provider.GetDictionary());
        }

        [Fact]
        public void GetDictionary_WithUnknownFilename_ThrowsFileNotFoundException()
        {
            var provider = new FileDictionaryProvider(UnknowFile);
            var exception = Assert.Throws<FileNotFoundException>(() => provider.GetDictionary());

            Assert.Contains(UnknowFile, exception.Message); // Error should contain filename
        }

        [Fact]
        public void GetDictionary_WithKnownFilename_ReturnsListOfStrings()
        {
            var provider = new FileDictionaryProvider(KnownFile);
            var actual = provider.GetDictionary();
        }
    }
}
