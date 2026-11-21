using SolarSystemPrj.DTOs;
using SolarSystemPrj.DTOs.SolarSystemPrj.DTOs;
using SolarSystemPrj.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace SolarSystemPrj.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpclient;

        public HttpClientService(HttpClient httpclient, string baseUrl, string apiKey)
        {
            _httpclient = httpclient;
            _httpclient.BaseAddress = new Uri(baseUrl);

            _httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<List<BodyDto>> GetBodiesAsync()
        {
            using var response = await _httpclient.GetAsync("bodies/");

            var result = await response.Content.ReadFromJsonAsync<SolarSystemResponseDto>();

            if (result?.Bodies == null || result?.Bodies.Count() == 0)
                throw new Exception("An error occured");

            return result!.Bodies;
        }
    }
}
