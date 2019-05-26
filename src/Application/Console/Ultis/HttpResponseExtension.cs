using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBankingApp.Ultis
{
    public static class HttpResponseExtension
    {
        public static async Task<T> DeserilizeResponseAsync<T>(this HttpResponseMessage httpResponseMessage)
        {
            var serializer = new JsonSerializer();
            using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync())
            using (var sr = new StreamReader(stream))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                return serializer.Deserialize<T>(jsonTextReader);
            }
        }
    }
}
