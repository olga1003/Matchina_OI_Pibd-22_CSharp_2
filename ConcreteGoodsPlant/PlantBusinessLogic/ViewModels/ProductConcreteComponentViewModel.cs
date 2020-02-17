using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PlantBusinessLogic.ViewModels
{
    /// Сколько компонента, требуется при изготовлении изделия 
    public class ProductConcreteComponentViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int ComponentId { get; set; }

        [DisplayName("Компонент")] public string ComponentName { get; set; }

        [DisplayName("Количество")] public int Count { get; set; }
    }
}
