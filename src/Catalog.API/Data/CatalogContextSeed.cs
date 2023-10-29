using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public async static void SeedData(IMongoCollection<Product> productCollection)
        {
            if (productCollection.Find(p => true).Any())
                return;

          await  productCollection.InsertManyAsync(GetPreconfigProds());
        }

        private static IEnumerable<Product> GetPreconfigProds()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Id = "e1204e09efb548b4b27ee2cf",
                    Name = "IPhone X",
                    Description = "This is a top phone",
                    ImageFile = "product.png",
                    Price = 1020M,
                    Category = "Smart Phone"

                },
                new Product()
                {
                    Id = "55b60093fc38443883de5b5e",
                    Name = "Samsung Z fold",
                    Description = "This is a top phone",
                    ImageFile = "sams.png",
                    Price = 2000M,
                    Category = "Smart Phone"
                }
            };
        }
    }
}
