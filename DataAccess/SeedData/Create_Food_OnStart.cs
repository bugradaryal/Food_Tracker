using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                    int dbfoodcount = DbContext.Foods.Count();
                    if (dbfoodcount != 0)
                    {
                        if (ınsert.Food_Data() != null)
                        {
                            var i = ınsert.Food_Data().Count();
                            if (dbfoodcount < ınsert.Food_Data().Count)
                            {
                                foreach (var dbfood in ınsert.Food_Data())
                                {
                                    if (DbContext.Foods.Any(x => x.id == dbfood.id) == false)
                                    {
                                        DbContext.Foods.Add(dbfood);
                                    }
                                }
                                DbContext.SaveChanges();
                            }
                            else if (dbfoodcount > ınsert.Food_Data().Count)
                            {
                                foreach (var dbfood in DbContext.Foods.ToList())
                                {
                                    if (ınsert.Food_Data().Any(x => x.id == dbfood.id) == false)
                                    {
                                        DbContext.Foods.Remove(dbfood);
                                    }
                                }
                                DbContext.SaveChanges();
                            }
                        }
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
