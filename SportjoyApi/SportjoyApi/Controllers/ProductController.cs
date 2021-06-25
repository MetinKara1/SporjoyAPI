using Api.DTO;
using AutoMapper;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sporjoy.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService _productService, IMapper mapper)
        {
            this._mapper = mapper;
            this._productService = _productService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            var productResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);

            return Ok(productResources);
        }
    }
}
