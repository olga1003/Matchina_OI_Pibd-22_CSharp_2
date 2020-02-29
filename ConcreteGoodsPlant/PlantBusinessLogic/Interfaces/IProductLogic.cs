using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> Read(ProductConcreteBindingModel model);
        void CreateOrUpdate(ProductConcreteBindingModel model);
        void Delete(ProductConcreteBindingModel model);
    }
}