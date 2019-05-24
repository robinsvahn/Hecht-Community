using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HechtCommunity.DTOs;
using Newtonsoft.Json;

namespace HechtCommunity.Services.Impl
{
    internal class CoworkingService : ICoworkingService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = $"https://hechtcommunitybackend-api.azurewebsites.net/api/tablebooking";


        public CoworkingService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> IsTableVacant(int tableId)
        {
            var result = await _httpClient.GetAsync($"{_baseUri}/{tableId}");
            var value = await result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<bool>(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">Written as PascalCase because of property binding on receiving end</param>
        /// <returns></returns>
        public async Task<string> BookTableById(int tableId)
        {
            var table = new TableDto(tableId);
            var tableString = JsonConvert.SerializeObject(table);
            var content = new StringContent(tableString, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync($"{_baseUri}", content);
            var value = await result.Content.ReadAsStringAsync();

            return value;
        }

        public async Task<string> UnbookTableById(int tableId)
        {
            var result = await _httpClient.PutAsync($"{_baseUri}/{tableId}", null);
            var value = await result.Content.ReadAsStringAsync();

            return value;
        }
    }
}
