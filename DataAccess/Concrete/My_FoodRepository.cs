using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class My_FoodRepository : IMy_FoodRepository
    {
        public My_Food CreateMy_Food(My_Food My_Food)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.My_Foods.Add(My_Food);
                DbContext.SaveChanges();
                return My_Food;
            }
        }

        public My_Food DeleteMy_Food(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletedMy_Food = GetMy_FoodById(id);
                DbContext.My_Foods.Remove(deletedMy_Food);
                DbContext.SaveChanges();
                return deletedMy_Food;
            }
        }

        public List<My_Food> GetAllMy_Foods(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.My_Foods.Where(x=>x.Fridges_id == id).ToList();
            }
        }

        public My_Food GetMy_FoodById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.My_Foods.Find(id);
            }
        }

        public bool GetMy_FoodByFoodId(int fridgeid, int foodid)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.My_Foods.Where(x => x.Fridges_id == fridgeid).ToList().Any(x => x.Foods_id == foodid);
            }
        }
        public My_Food GetMy_FoodByFrıdgeIdFoodId(int fridgeid, int foodid)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.My_Foods.Where(x => x.Fridges_id == fridgeid).ToList().FirstOrDefault(x => x.Foods_id == foodid);
            }
        }

        public My_Food UpdateMy_Food(My_Food My_Food)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.My_Foods.Update(My_Food);
                return My_Food;
            }
        }
        public List<My_Food> GetMy_FoodByFridgeId(int fridgeid)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.My_Foods.Where(x => x.Fridges_id == fridgeid).ToList();
            }
        }            
    }
}
