using System;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using PlantBusinessLogic.HelperModels;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PlantBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IWarehouseLogic warehouseLogic;
        private readonly IProductLogic productLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IProductLogic productLogic, IWarehouseLogic warehouseLogic,
       IOrderLogic orderLLogic)
        {
            this.productLogic = productLogic;
            this.warehouseLogic = warehouseLogic;
            this.orderLogic = orderLLogic;
        }

        public List<ReportProductComponentViewModel> GetProductComponent()
        {         
            var products = productLogic.Read(null);
            var list = new List<ReportProductComponentViewModel>();

            foreach (var product in products)
            {
                foreach (var pc in product.ProductComponents)
                {
                    var record = new ReportProductComponentViewModel
                    {
                        ProductName = product.ProductName,
                        ComponentName = pc.Value.Item1,
                        Count = pc.Value.Item2
                    };

                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportWarehouseComponentViewModel> GetWarehouseComponents()
        {
            var wahehouses = warehouseLogic.GetList();
            var list = new List<ReportWarehouseComponentViewModel>();

            foreach (var wahehouse in wahehouses)
            {
                foreach (var wc in wahehouse.WarehouseComponents)
                {
                    var record = new ReportWarehouseComponentViewModel
                    {
                        WarehouseName = wahehouse.WarehouseName,
                        ComponentName = wc.ComponentName,
                        Count = wc.Count
                    };

                    list.Add(record);
                }
            }
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic
            .Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(recG => recG.Key)
            .ToList();

            return list;
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Products = productLogic.Read(null)
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveProductComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список издлий с компонентами",
                ProductComponents = GetProductComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
           public void SaveOrdersToExcelFile(ReportBindingModel model)
           {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Products = null,
                Warehouses = warehouseLogic.GetList()
            });
        }

        public void SaveWarehouseComponentsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонентов в складах",
                Orders = null,
                Warehouses = warehouseLogic.GetList()
            });
        }

        public void SaveComponentsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Компонентов",
                ProductComponents = null,
                WarehouseComponents = GetWarehouseComponents()
            });
        }
    }
}