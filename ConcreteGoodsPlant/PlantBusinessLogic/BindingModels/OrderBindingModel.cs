﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.BindingModels
{
    /// Заказ     
    public class OrderBindingModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
