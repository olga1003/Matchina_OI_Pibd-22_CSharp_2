using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public List<WarehouseViewModel> Warehouses { get; set; }
    }
}
