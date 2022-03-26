using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class FoodRepository : IFoodRepository
    {
        public Food CreateFood(Food Food)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Foods.Add(Food);
                DbContext.SaveChanges();
                return Food;
            }
        }

        public void DeleteFood(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletedFood = GetFoodById(id);
                DbContext.Foods.Remove(deletedFood);
                DbContext.SaveChanges();
            }
        }

        public List<Food> GetAllFoods()
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Foods.ToList();
            }
        }

        public Food GetFoodById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Foods.Find(id);
            }
        }

        public Food UpdateFood(Food Food)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Foods.Update(Food);
                return Food;
            }
        }
    }
}
