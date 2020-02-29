using System;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        List<OrderViewModel> Read(OrderBindingModel model);
        void CreateOrUpdate(OrderBindingModel model);
        void Delete(OrderBindingModel model);
    }
}
