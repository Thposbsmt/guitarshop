using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    [Table("user")]
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(60, ErrorMessage = "Имя до 60 символов")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Телефон обязателен")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Корректно телефон")]
        public string PhoneNumber { get; set; }

        [StringLength(30, ErrorMessage = "Корректный адресс")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Пароль обязательно")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Роль обязательно")]
        public string Role { get; set; }

        public double TotalSpend { get; set; }
        public double Discount { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
