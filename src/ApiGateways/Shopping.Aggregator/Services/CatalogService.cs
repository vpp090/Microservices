using Shopping.Aggregator.Models;
using Shopping.Aggregator.Extensions;

namespace Shopping.Aggregator.Services
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
            var response = await _client.GetAsync("/api/Catalog");
            var result = await response.ReadContentAs<List<CatalogModel>>();

            return result;
        }

        public async Task<CatalogModel> GetCatalog(string id)
        {
            var response = await _client.GetAsync($"/api/Catalog/{id}");
            var result = await response.ReadContentAs<CatalogModel>();

            return result;
        }

        public async Task<IEnumerable<CatalogModel>> GetCatalogByCategory(string category)
        {
            var response = await _client.GetAsync($"/api/Catalog/GetProductByCategory{category}");
            var result = await response.ReadContentAs<List<CatalogModel>>();

            return result;
        }
    }
}
