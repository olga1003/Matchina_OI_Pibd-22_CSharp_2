using Microsoft.AspNetCore.Mvc;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using PlantRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseLogic _warehouse;
        private readonly IComponentLogic _component;

        public WarehouseController(IWarehouseLogic warehouse, IComponentLogic component)
        {
            _warehouse = warehouse;
            _component = component;
        }

        [HttpGet]
        public List<WarehouseModel> GetWarehousesList() => _warehouse.GetList()?.Select(rec => Convert(rec)).ToList();

        [HttpGet]
        public List<ComponentViewModel> GetComponentsList() => _component.Read(null)?.ToList();

        [HttpGet]
        public WarehouseModel GetWarehouse(int warehouseId) => Convert(_warehouse.GetElement(warehouseId));

        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _warehouse.UpdElement(model);
            }
            else
            {
                _warehouse.AddElement(model);
            }
        }

        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouse.DelElement(model);

        [HttpPost]
        public void ReplanishWarehouse(WarehouseComponentBindingModel model) => _warehouse.AddComponent(model);

        private WarehouseModel Convert(WarehouseViewModel model)
        {
            if (model == null) return null;

            return new WarehouseModel
            {
                Id = model.Id,
                WarehouseName = model.WarehouseName,
                WarehouseComponents = model.WarehouseComponents
            };
        }
    }
}