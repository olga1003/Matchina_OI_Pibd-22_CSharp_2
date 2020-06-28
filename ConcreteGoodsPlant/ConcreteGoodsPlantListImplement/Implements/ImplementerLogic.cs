using System;
using System.Collections.Generic;
using System.Text;
using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.Interfaces;
using PlantBusinessLogic.ViewModels;
using ConcreteGoodsPlantListImplement.Models;

namespace ConcreteGoodsPlantListImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly DataListSingleton source;

        public ImplementerLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer tempImplementer = new Implementer { Id = 1 };

            bool isImplementerExist = false;

            foreach (var implementer in source.Implementers)
            {

                if (implementer.ImplementerFIO == model.ImplementerFIO && implementer.Id != model.Id)
                {
                    throw new Exception("Уже есть испольнитель с таким фио");
                }
                if (implementer.Id >= tempImplementer.Id)
                {
                    tempImplementer.Id = implementer.Id + 1;
                }
                else if (implementer.Id == model.Id)
                {
                    tempImplementer = implementer;
                    isImplementerExist = true;
                    break;
                }
            }

            if (isImplementerExist)
            {
                CreateModel(model, tempImplementer);
            }
            else
            {
                source.Implementers.Add(CreateModel(model, tempImplementer));
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == model.Id)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }

            throw new Exception("Элемент не найден");
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();

            foreach (var implementer in source.Implementers)
            {
                if (model != null)
                {
                    if (implementer.Id == model.Id)
                    {
                        result.Add(CreateViewModel(implementer));
                        break;
                    }

                    continue;
                }

                result.Add(CreateViewModel(implementer));
            }

            return result;
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer Implementer)
        {
            Implementer.ImplementerFIO = model.ImplementerFIO;
            Implementer.WorkingTime = model.WorkingTime;
            Implementer.PauseTime = model.PauseTime;
            return Implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer Implementer)
        {
            return new ImplementerViewModel
            {
                Id = Implementer.Id,
                ImplementerFIO = Implementer.ImplementerFIO,
                WorkingTime = Implementer.WorkingTime,
                PauseTime = Implementer.PauseTime
            };
        }
    }
}