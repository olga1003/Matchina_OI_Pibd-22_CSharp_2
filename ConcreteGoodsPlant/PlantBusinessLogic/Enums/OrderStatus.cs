﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlantBusinessLogic.Enums
{
    public enum OrderStatus
    {
        Принят = 0,

        Выполняется = 1,

        Готов = 2,

        Оплачен = 3,
        Требуются_материалы = 4
    }
}