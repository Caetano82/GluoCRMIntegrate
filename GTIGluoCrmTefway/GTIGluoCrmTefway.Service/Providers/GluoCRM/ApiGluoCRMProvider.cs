using GTIGluoCrmTefway.IoC.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GTIGluoCrmTefway.Service.Providers.GluoCRM
{
    public class ApiGluoCRMProvider : IApiGluoCRMProvider
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly APIOption _config;

        public ApiGluoCRMProvider(IHttpContextAccessor httpContextAccessor, IOptions<APIOption> config)
        {
            _config = config.Value;
            _httpClient = new HttpClient { BaseAddress = new Uri(_config.APICRMGluo) };
            _httpContextAccessor = httpContextAccessor;
            _httpClient.Timeout = Timeout.InfiniteTimeSpan;
        }

        public async Task<string> GetAsync(string endpoint)
        {

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }
        }

        public async Task<string> PostAsync(string endpoint, string content)
        {
            var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, httpContent);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new HttpRequestException($"API request failed with status code {response.StatusCode}");
            }
        }
        public async Task<string> PostFormDataAsync(string endpoint, string operation, string username, string accessKey)
        {

            // Criando o conteúdo FormData
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(operation), "operation");
            content.Add(new StringContent(username), "username");
            content.Add(new StringContent(accessKey), "accessKey");

            // Criando a requisição HTTP POST
            var request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            request.Content = content;

            // Enviando a requisição POST e recebendo a resposta
            var response = await _httpClient.SendAsync(request);

            // Verificando se a requisição foi bem-sucedida
            response.EnsureSuccessStatusCode();

            // Lendo e retornando o conteúdo da resposta
            return await response.Content.ReadAsStringAsync();
        }
    }
}





