using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private IFoodRepository _FoodRepository;

        public FoodManager()
        {
            _FoodRepository = new FoodRepository();
        }

        public List<Food> GetAllFoods()
        {
            return _FoodRepository.GetAllFoods();
        }

        public Food GetFoodById(int id)
        {
            return _FoodRepository.GetFoodById(id);
        }
        public List<Food> SearchByname(string name)
        {
            return _FoodRepository.SearchByname(name);
        }
        public List<Food> Filter(List<Food> food, string islem)
        {
            return _FoodRepository.Filter(food, islem);
        }
    }
}
