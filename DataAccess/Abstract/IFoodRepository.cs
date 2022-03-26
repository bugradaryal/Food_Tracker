﻿using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IFoodRepository
    {
        List<Food> GetAllFoods();
        Food GetFoodById(int id);
        Food CreateFood(Food Food);
        Food UpdateFood(Food Food);
        void DeleteFood(int id);
    }
}
