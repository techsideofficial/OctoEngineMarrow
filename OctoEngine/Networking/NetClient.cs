using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Networking
{
    internal class NetClient
    {
        private readonly HttpClient client = new HttpClient();

        public void Get(string url, Action<string> onSuccess, Action<Exception> onError = null)
        {
            Task.Run(async () =>
            {
                try
                {
                    var response = await client.GetAsync(url);
                    string content = await response.Content.ReadAsStringAsync();
                    onSuccess?.Invoke(content);
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                }
            });
        }

        public void Post(string url, string data, string contentType, Action<string> onSuccess, Action<Exception> onError = null)
        {
            Task.Run(async () =>
            {
                try
                {
                    var content = new StringContent(data, Encoding.UTF8, contentType);
                    var response = await client.PostAsync(url, content);
                    string result = await response.Content.ReadAsStringAsync();
                    onSuccess?.Invoke(result);
                }
                catch (Exception ex)
                {
                    onError?.Invoke(ex);
                }
            });
        }
    }

}
