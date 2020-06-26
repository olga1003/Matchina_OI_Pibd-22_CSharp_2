using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using ConcreteGoodsPlantDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ConcreteGoodsPlantDatabaseImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element == null)
                {
                    element = new Implementer();
                    context.Implementers.Add(element);
                }


                element.ImplementerFIO = model.ImplementerFIO;
                element.WorkingTime = model.WorkingTime;
                element.PauseTime = model.PauseTime;
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Implementer element = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (element != null)
                {
                    context.Implementers.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                return context.Implementers
                .Where(
                    rec => model == null
                    || (rec.Id == model.Id)
                )
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    ImplementerFIO = rec.ImplementerFIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }
    }
}