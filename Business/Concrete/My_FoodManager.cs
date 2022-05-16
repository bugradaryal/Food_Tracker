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

        public void DeleteMy_Food(int id, int idf)
        {
            _My_FoodRepository.DeleteMy_Food(id, idf);
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
    }
}
