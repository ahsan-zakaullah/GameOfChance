using GameOfChance.Api.Test.Integration.Utilities;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameOfChance.Api.Test.Integration.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static Task<T> DeserializeContent<T>(this HttpResponseMessage message)
        {
            return JsonUtils.DeserializeAsync<T>(message.Content.ReadAsStreamAsync());
        }
    }
}
