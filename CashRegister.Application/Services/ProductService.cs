using AutoMapper;
using CashRegister.API.Dto;
using CashRegister.Application.Interface;
using CashRegister.Domain.Models;
using CashRegister.Infrastructure.Interface;

namespace CashRegister.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepo, IMapper mapper)
        {
            _productRepository = productRepo;
            _mapper = mapper;
        }

        public Task<bool> CreateNewProduct(Product product)
        {
            var addResult = _productRepository.CreateNewProduct(product);
            return addResult;
        }
        public bool UpdateProduct(int id, ProductDto productDto)
        {
            productDto.Id = id;
            var mappedDtoToProduct = _mapper.Map<Product>(productDto);
            var updateResult = _productRepository.UpdateProduct(mappedDtoToProduct);
            return updateResult;
        }

        public  bool DeleteProduct(int id)
        {
            var product = _productRepository.GetProductById(id);
            var deleteProduct = _productRepository.DeleteProduct(product);
            return deleteProduct;
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id: id);
            return product;
        }

        public Task<List<Product>> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return products;
        }

        public bool CheckIfProductExists(int id)
        {
            var result = _productRepository.CheckIfProductExists(id);
            return result;
        }


    }
}
