using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IFoodRepository
    {
        List<Food> GetAllFoods();
        Food GetFoodById(int id);
        List<Food> SearchByname(string name);
        List<Food> Filter(List<Food> food, string islem);
    }
}

