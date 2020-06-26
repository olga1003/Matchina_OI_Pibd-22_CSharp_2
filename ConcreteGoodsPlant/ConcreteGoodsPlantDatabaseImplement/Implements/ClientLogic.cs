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
    public class ClientLogic : IClientLogic
    {
        public void CreateOrUpdate(ClientBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Email == model.Email && rec.Id != model.Id);
                if (element != null)
                {
                    throw new Exception("Уже есть такой клиент");
                }
                if (model.Id.HasValue)
                {
                    element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Client();
                    context.Clients.Add(element);
                }
                element.FIO = model.ClientFIO;
                element.Password = model.Password;
                element.Email = model.Email;
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            using (var context = new ConcreteGoodsPlantDatabase())
            {
                List<ClientViewModel> clients = context.Clients.Where(
                    rec => model == null
                    || (rec.Id == model.Id)
                    || (rec.Email == model.Email && rec.Password == model.Password)
                ).Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFIO = rec.FIO,
                    Email = rec.Email,
                    Password = rec.Password
                })
                .ToList();
                if (clients.Count > 0)
                    return clients;
                return null;
            }
        }
    }
}