﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace AspnetRunBasics.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return default;

            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

           var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions {  PropertyNameCaseInsensitive = true });
        }

        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient client, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return client.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return httpClient.PutAsync(url, content);
        }
    }

    
}
