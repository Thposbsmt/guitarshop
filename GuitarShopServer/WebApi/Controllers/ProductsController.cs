using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTO.ProductDto;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _repository.Product.GetAllProducts();
                _logger.LogInfo("Returned all products from db");

                var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
                return Ok(productsResult);
            }
            catch(Exception ex)
            {
                _logger.LogError($"getallproducts /api/products -> {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _repository.Product.GetProductById(id);

                if(product == null)
                {
                    _logger.LogError($"Product with id {id} hasn't been found in db");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned product with id {id}");
                    var productResult = _mapper.Map<ProductDto>(product);

                    return Ok(productResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"getproductbyid /api/products/id -> {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductForCreationDto product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogError("Product object sent from client is null.");
                    return BadRequest("Product object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid product object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productEntity = _mapper.Map<Product>(product);

                _repository.Product.CreateProduct(productEntity);
                _repository.Save();

                var createdProduct = _mapper.Map<ProductDto>(productEntity);
                _logger.LogInfo($"Created new product with id {createdProduct.Id}");

                return Ok(createdProduct);  
            }
            catch (Exception ex)
            {
                _logger.LogError($"createproduct post api products -> {ex}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}