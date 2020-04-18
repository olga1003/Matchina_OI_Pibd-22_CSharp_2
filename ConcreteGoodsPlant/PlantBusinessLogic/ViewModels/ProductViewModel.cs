using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PlantBusinessLogic.ViewModels
{
    /// Изделие, изготавливаемое в магазине   
    [DataContract]
    public class ProductViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название изделия")]
        public string ProductName { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> ProductComponents { get; set; }
    }
}
