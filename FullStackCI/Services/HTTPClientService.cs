using FullStackCI.Dtos;
using FullStackCI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FullStackCI.Services
{
    public class HTTPClientService(IHttpClientFactory httpClientFactory)
    {
        private readonly IHttpClientFactory _httpClient = httpClientFactory;

        public async Task<RespuestaHacienda> getHaciendaResponse(string cedula)
        {
            try
            {
                var cliente = _httpClient.CreateClient();
                var response = await cliente.GetAsync($"https://api.hacienda.go.cr/fe/ae?identificacion={cedula}");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<RespuestaHacienda>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return data;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
