using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product newArtist);
        Task UpdateProduct(Product artistToBeUpdated, Product artist);
        Task DeleteProduct(Product artist);
    }
}
