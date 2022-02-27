using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameOfChance.Api.Test.Integration.Utilities
{
    public class QueryParamBuilder
    {
        private readonly Dictionary<string, string> _fields = new();
        public QueryParamBuilder Add(string key, string value)
        {
            _fields.Add(key, value);
            return this;
        }
        public string Build()
        {
            var hasParameters = _fields.Count != 0;
            return hasParameters ? $"?{string.Join("&", _fields.Select(pair => $"{HttpUtility.UrlEncode(pair.Key)}={HttpUtility.UrlEncode(pair.Value)}"))}" : "";
        }
        public static QueryParamBuilder New => new();
    }
}
