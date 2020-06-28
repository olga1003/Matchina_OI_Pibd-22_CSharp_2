using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using PlantBusinessLogic.Attributes;
using PlantBusinessLogic.Enums;
namespace PlantBusinessLogic.ViewModels
{
    [DataContract]
    class ProductComponentViewModel : BaseViewModel
    {
        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int ComponentId { get; set; }

        [DataMember]
        [Column(title: "Компонент", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string ComponentName { get; set; }

        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        public override List<string> Properties() => new List<string>
        {
            "Id",
            "ComponentName",
            "Count"
        };
    }
}
