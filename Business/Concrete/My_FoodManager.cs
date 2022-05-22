using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class My_FoodManager : IMy_FoodService
    {
        private IMy_FoodRepository _My_FoodRepository;

        public My_FoodManager()
        {
            _My_FoodRepository = new My_FoodRepository();
        }

        public My_Food CreateMy_Food(My_Food My_Food)
        {
            return _My_FoodRepository.CreateMy_Food(My_Food);
        }

        public My_Food DeleteMy_Food(int id)
        {
            return _My_FoodRepository.DeleteMy_Food(id);
        }

        public List<My_Food> GetAllMy_Foods(int id)
        {
            return _My_FoodRepository.GetAllMy_Foods(id);
        }

        public My_Food GetMy_FoodById(int id)
        {
            return _My_FoodRepository.GetMy_FoodById(id);
        }

        public My_Food UpdateMy_Food(My_Food My_Food)
        {
            return _My_FoodRepository.UpdateMy_Food(My_Food);
        }

        public bool GetMy_FoodByFrıdgeIdFoodIdAny(int fridgeid, int foodid)
        {
            return _My_FoodRepository.GetMy_FoodByFoodId(fridgeid, foodid);
        }
        public My_Food GetMy_FoodByFrıdgeIdFoodId(int fridgeid, int foodid)
        {
            return _My_FoodRepository.GetMy_FoodByFrıdgeIdFoodId(fridgeid, foodid);
        }
        public List<My_Food> GetMy_FoodByFridgeId(int fridgeid)
        {
            return _My_FoodRepository.GetMy_FoodByFridgeId(fridgeid);
        }
    }
}
