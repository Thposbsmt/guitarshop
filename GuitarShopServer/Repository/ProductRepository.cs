using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return FindAll()
                .OrderBy(pr => pr.Name)
                .ToList();
        }

        public Product GetProductById(int productId)
        {
            return FindByCondition(product => product.Id.Equals(productId))
                .FirstOrDefault();
        }
    }
}
