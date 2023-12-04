using AspnetRunBasics.Contracts;
using AspnetRunBasics.Extensions;
using AspnetRunBasics.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspnetRunBasics.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly HttpClient _client;  

        public CatalogService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalog()
        {
            var response = await _client.GetAsync("/Catalog");
            var result = await response.ReadContentAs<List<CatalogModel>>();

            return result;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/Catalog/GetProductByCategory/{category}");
            var result = await response.ReadContentAs<List<CatalogModel>>();

            return result;
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/Catalog/{id}");
            var result = await response.ReadContentAs<CatalogModel>();

            return result;
        }

        public async Task<CatalogModel> CreateCatalog(CatalogModel model)
        {
            CatalogModel result;
            var response = await _client.PostAsJson($"/Catalog", model);
            if (response.IsSuccessStatusCode)
            {
                result = await response.ReadContentAs<CatalogModel>();
                return result;
            }
            else
            {
                throw new System.Exception("Something went wrong");
            }

        }       
    }
}
