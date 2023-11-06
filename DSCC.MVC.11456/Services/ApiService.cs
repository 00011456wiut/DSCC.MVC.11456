using System;
using System.Text;
using System.Text.Json;
using Azure;
using DSCC.MVC._11456.Models;
using Newtonsoft.Json;

namespace DSCC.MVC._11456.Services
{
	public class ApiService: IApiService
	{
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiBaseUrl"];
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        // Blogs
        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
           return await _httpClient.GetFromJsonAsync<IEnumerable<Blog>>(_apiBaseUrl + "blogs");
        }

        public async Task<Blog> GetBlogById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Blog>(_apiBaseUrl + $"blogs/{id}");
        }

        public async Task UpdateBlog(int id, Blog blog)
        {
            // Serialize the Blog object to JSON and create a StringContent
            string jsonContent = JsonConvert.SerializeObject(blog); // Make sure to include the appropriate JSON serialization library (e.g., Newtonsoft.Json).
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = await _httpClient.PutAsync(_apiBaseUrl + $"blogs/{id}", content);
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteBlog(int id)
        {
           var result = await _httpClient.DeleteAsync(_apiBaseUrl + $"blogs/{id}");
           result.EnsureSuccessStatusCode();
        }

        // University
        public async Task<IEnumerable<University>> GetAllUniversities()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<University>>(_apiBaseUrl + "universities");
        }

        public async Task<University> GetUniversityById(int id)
        {
            return await _httpClient.GetFromJsonAsync<University>(_apiBaseUrl + $"universities/{id}");
        }

        public async Task UpdateUniversity(int id, University university)
        {
            // Serialize the Blog object to JSON and create a StringContent
            string jsonContent = JsonConvert.SerializeObject(university); // Make sure to include the appropriate JSON serialization library (e.g., Newtonsoft.Json).
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = await _httpClient.PutAsync(_apiBaseUrl + $"universities/{id}", content);
            result.EnsureSuccessStatusCode();
        }

        public async Task DeleteUniversity(int id)
        {
            var result = await _httpClient.DeleteAsync(_apiBaseUrl + $"universities/{id}");
            result.EnsureSuccessStatusCode();
        }

        public async Task CreateUniversity(University university)
        {
            // Serialize the Blog object to JSON and create a StringContent
            string jsonContent = JsonConvert.SerializeObject(university); // Make sure to include the appropriate JSON serialization library (e.g., Newtonsoft.Json).
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = await _httpClient.PostAsync(_apiBaseUrl + "universities", content);
            result.EnsureSuccessStatusCode();
        }
    }
}

