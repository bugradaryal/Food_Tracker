using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class FridgeRepository : IFridgeRepository
    {
        public Fridge CreateFridge(Fridge Fridge)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Fridges.Add(Fridge);
                DbContext.SaveChanges();
                return Fridge;
            }
        }

        public void DeleteFridge(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                var deletedFridge = GetFridgeById(id);
                DbContext.Fridges.Remove(deletedFridge);
                DbContext.SaveChanges();
            }
        }

        public List<Fridge> GetAllFridges()
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Fridges.ToList();
            }
        }

        public Fridge GetFridgeById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Fridges.Find(id);
            }
        }

        public Fridge UpdateFridge(Fridge Fridge)
        {
            using (var DbContext = new DataDbContext())
            {
                DbContext.Fridges.Update(Fridge);
                return Fridge;
            }
        }
    }
}
