using Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFoodService
    {
        List<Food> GetAllFoods();
        Food GetFoodById(int id);
        Food CreateFood(Food Food);
        Food UpdateFood(Food Food);
        void DeleteFood(int id);
        List<Food> SearchByname(string name);
        List<Food> Filter(List<Food> food, string islem);
    }
}

