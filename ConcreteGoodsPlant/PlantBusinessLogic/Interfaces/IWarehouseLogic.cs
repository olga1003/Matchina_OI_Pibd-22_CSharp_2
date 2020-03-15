using PlantBusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public class IWarehouseLogic
    {

        List<WarehouseViewModel> GetList();

        WarehouseViewModel GetElement(int id);

        void AddElement(WarehouseBindingModel model);

        void UpdElement(WarehouseBindingModel model);

        void DelElement(int id);

        void AddComponent(WarehouseComponentBindingModel model);
    }
}
