namespace DR.Configuration.Parsers
{
    using System.Collections.Specialized;

    public interface IConfigurationParseStrategy
    {
        void Parse(NameValueCollection nameValueCollection);
    }
}
