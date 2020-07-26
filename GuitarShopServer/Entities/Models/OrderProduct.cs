using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    [Table("orderproduct")]
    public class OrderProduct : BaseEntity
    {
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
