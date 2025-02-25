﻿using Entities;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IFridgeService
    {
        List<Fridge> GetAllFridgesByUserId(int id);
        Fridge GetFirstFridgeByUserId(int id);
        Fridge GetFridgeById(int id);
        Fridge CreateFridge(Fridge Fridge);
        Fridge UpdateFridge(Fridge Fridge);
        void DeleteFridge(int id);
    }
}
