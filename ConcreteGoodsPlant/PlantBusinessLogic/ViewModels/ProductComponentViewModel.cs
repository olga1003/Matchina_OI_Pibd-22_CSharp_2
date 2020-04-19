using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace PlantBusinessLogic.ViewModels
{
    [DataContract]
    class ProductComponentViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int ComponentId { get; set; }

        [DataMember]
        [DisplayName("Компонент")]
        public string ComponentName { get; set; }

        [DataMember]
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
