using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project.Client.Repositorios
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string> GetBody()
        {
            return await HttpResponseMessage.Content.ReadAsStringAsync();
        }
        public async Task<TResponse> GetBodyAsJsonAsync<TResponse>()
        {
            var responseString = await HttpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
