using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;


namespace GameZone.Models
{
    public class ManageApi
    {
        private readonly HttpClient _httpClient;
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public ManageApi(HttpClient httpClient) /*IHttpContextAccessor httpContextAccessor)*/
        {
            _httpClient = httpClient;
            //    _httpContextAccessor = httpContextAccessor;
            //}
            //private void SetAuthorizationHeader()
            //{
            //    var token = _httpContextAccessor.HttpContext.Session.GetString("JWTToken");
            //    if (!string.IsNullOrEmpty(token))
            //    {
            //        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            //    }
            //}
            }
        public async Task<T> GetAsync<T>(string url)
        {
            
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            return default;
        }
        public async Task<bool> PostAsync<T>(string url, T data)
        {
            //SetAuthorizationHeader();
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> PutAsync<T>(string url, T data)
        {
            //SetAuthorizationHeader();
            var jsonContent = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync(url, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string url)
        {
            //SetAuthorizationHeader();
            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}