using System;
using System.Linq;
using ObjectsComparer;
using Entities;


namespace DataAccess.SeedData
{
    public static class Create_Food_OnStart
    {
        public static void create()
        {
            try
            {
                using (var DbContext = new DataDbContext())
                {
                    Insert_Foods ınsert = new Insert_Foods();
                    if (DbContext.Foods.Count() != 0)
                    {
                        foreach (var dbfood in DbContext.Foods.ToList())
                        {
                            if (ınsert.Food_Data().Any(x => x.id == dbfood.id) == false)
                            {
                                DbContext.Foods.Remove(dbfood);
                            }
                            else
                            {
                                Food data = ınsert.Food_Data().FirstOrDefault(x => x.id == dbfood.id);
                                var compare = new Comparer();
                                if (compare.Compare(data, dbfood) != true)
                                {
                                    using (var DbUpdate = new DataDbContext())
                                    {
                                        DbUpdate.Foods.Update(data);
                                        DbUpdate.SaveChanges();
                                    }
                                }
                            }
                        }
                        foreach (var dbfood in ınsert.Food_Data())
                        {
                            if (DbContext.Foods.Any(x => x.id == dbfood.id) == false)
                            {
                                DbContext.Foods.Add(dbfood);
                            }
                        }
                        DbContext.SaveChanges();
                    }
                    else
                    {
                        foreach (var dbfood in ınsert.Food_Data())
                        {
                            DbContext.Foods.Add(dbfood);
                        }
                        DbContext.SaveChanges();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
