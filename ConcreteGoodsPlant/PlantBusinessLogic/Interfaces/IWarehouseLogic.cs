using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> GetList();

        WarehouseViewModel GetElement(int id);

        void AddElement(WarehouseBindingModel model);

        void UpdElement(WarehouseBindingModel model);

        void DelElement(WarehouseBindingModel model);

        void AddComponent(WarehouseComponentBindingModel model);
        void DeleteFromWarehouse(int ProductId, int ProductsCount);
    }
}
