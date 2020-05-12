﻿using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParksRec.Client.Helpers
{
    public class Requests
    {
        private readonly HttpClient _httpClient;

        public Requests(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetContent(Uri uri)
        {
            return await GetContent(uri.ToString());
        }

        public async Task<string> GetContent(string uri)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            using var response = await _httpClient.SendAsync(request);
            {
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                content = content.Replace("\"null\"", "null");

                return content;
            }
        }
    }
}