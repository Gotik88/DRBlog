namespace DR.Data.Structures.Extensions
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    public static class CollectionExtension
    {
        public static IDictionary<string, string> ToDictionary(this NameValueCollection collection)
        {
            return collection.Cast<string>().ToDictionary(k => k, v => collection[v]);
        }
    }
}
