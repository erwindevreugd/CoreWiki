using System.Collections.Generic;

namespace CoreWiki.Extensibility.TheChapel
{
    public interface IDictionaryProvider
    {
        IEnumerable<string> GetDictionary();
    }
}