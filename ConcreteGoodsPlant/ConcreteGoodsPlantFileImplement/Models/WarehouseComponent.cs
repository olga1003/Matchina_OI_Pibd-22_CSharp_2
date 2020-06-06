using System;
using System.Collections.Generic;
using System.Text;

namespace ConcreteGoodsPlantFileImplement.Models
{
    public class WarehouseComponent
    {
        public int Id { get; set; }

        public int WarehouseId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
