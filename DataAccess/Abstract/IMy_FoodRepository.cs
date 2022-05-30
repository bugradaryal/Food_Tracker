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
        My_Food DeleteMy_Food(int id);
        bool GetMy_FoodByFoodId(int fridgeid, int foodid);
        My_Food GetMy_FoodByFrıdgeIdFoodId(int fridgeid, int foodid);
        List<My_Food> GetMy_FoodByFridgeId(int fridgeid);
        List<My_Food> Filter(List<My_Food> My_Food, string islem);
    }
}
