using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantRestApi.Models
{
    public class WarehouseModel
    {
        public int Id { get; set; }

        public string WarehouseName { get; set; }
        public List<WarehouseComponentViewModel> WarehouseComponents { get; set; }

    }
}
