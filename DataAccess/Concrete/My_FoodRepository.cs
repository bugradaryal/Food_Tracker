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

        public void DeleteMy_Food(int id, int idf)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.My_Foods.Remove(DbContext.My_Foods.Where(x => x.Fridges_id == id).ToList().Where(x => x.Foods_id == idf).FirstOrDefault());
                DbContext.SaveChanges();
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

        public My_Food UpdateMy_Food(My_Food My_Food)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.My_Foods.Update(My_Food);
                return My_Food;
            }
        }
    }
}
