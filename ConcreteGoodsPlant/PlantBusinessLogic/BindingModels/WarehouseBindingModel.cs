using PlantBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.BindingModels
{
    public class WarehouseBindingModel
    {
        public int? Id { get; set; }
        public string WarehouseName { get; set; }
        public List<WarehouseComponentBindingModel> WarehouseComponent { get; set; }
    }
}
