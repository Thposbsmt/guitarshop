using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
        [Table("product")]
        public class Product : BaseEntity
        {
            [Required(ErrorMessage = "Название товара обязательно")]
            [StringLength(30, ErrorMessage = "Длина названия не может быть больше 30 символов")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Содержимое обязательно")]
            [StringLength(200, ErrorMessage = "Длина описания не может быть больше 200 символов")]
            public string Description { get; set; }

            [Required(ErrorMessage = "Цена должна быть указана")]
            public double Price { get; set; }

            [Required(ErrorMessage = "Тип товара обязателен")]
            [StringLength(maximumLength: 15, MinimumLength = 3, ErrorMessage = "Тип должен состоять из 3-15 символов")]
            public string Type { get; set; }

            public string ImgPath { get; set; }

            public bool InStock { get; set; }
        }
}
