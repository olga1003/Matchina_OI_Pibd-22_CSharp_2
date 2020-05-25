using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using PlantBusinessLogic.Attributes;
using PlantBusinessLogic.Enums;

namespace PlantBusinessLogic.ViewModels
{
    
    /// Изделие, изготавливаемое в магазине   
    [DataContract]
    public class ProductViewModel: BaseViewModel
    { 
        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ProductName { get; set; }
        [Column(title: "Цена", width: 100)]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ProductName",
            "Price"
        };
    }
}
