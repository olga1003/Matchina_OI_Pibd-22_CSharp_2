using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConcreteGoodsPlantDatabaseImplement.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual ProductComponent  ProductComponent { get; set; }

    }
}
