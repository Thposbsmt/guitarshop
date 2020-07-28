using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.ProductDto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }
        public bool InStock { get; set; }
        public string ImgPath { get; set; }
    }
}
