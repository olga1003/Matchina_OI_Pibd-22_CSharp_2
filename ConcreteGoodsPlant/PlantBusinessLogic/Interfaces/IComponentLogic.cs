﻿using PlantBusinessLogic.BindingModels;
using PlantBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Interfaces
{
    public interface IComponentLogic
    {
        List<ComponentViewModel> GetList();

        ComponentViewModel GetElement(int id);

        void AddElement(ComponentBindingModel model);

        void UpdElement(ComponentBindingModel model);

        void DelElement(int id);
    }
}