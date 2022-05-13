using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IMy_FoodRepository
    {
        List<My_Food> GetAllMy_Foods(int id);
        My_Food GetMy_FoodById(int id);
        My_Food CreateMy_Food(My_Food My_Food);
        My_Food UpdateMy_Food(My_Food My_Food);
        void DeleteMy_Food(int id);
    }
}
