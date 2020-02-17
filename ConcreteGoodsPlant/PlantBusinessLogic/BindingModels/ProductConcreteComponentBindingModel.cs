using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.BindingModels
{
    /// Сколько компонента, требуется при изготовлении изделия 
    public class ProductConcreteComponentBindingModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int ComponentId { get; set; }

        public int Count { get; set; }
    }
}
