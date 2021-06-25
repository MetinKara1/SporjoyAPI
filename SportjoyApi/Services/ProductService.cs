using Core.Models;
using Sporjoy.Core.Services;
using Sporjoy.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sporjoy.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            await _unitOfWork.Products
                .AddAsync(newProduct);

            return newProduct;
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Products.Remove(product);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products.GetByIdAsync(id);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.ProductName = product.ProductName;

            await _unitOfWork.CommitAsync();
        }
    }

}
