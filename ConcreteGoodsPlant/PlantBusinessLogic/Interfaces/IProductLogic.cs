using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IProductLogic
    {
        List<ProductViewModel> GetList();

        ProductViewModel GetElement(int id);

        void AddElement(ProductConcreteBindingModel model);

        void UpdElement(ProductConcreteBindingModel model);

        void DelElement(int id);
    }
}