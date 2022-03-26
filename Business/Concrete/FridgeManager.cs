using Business.Abstract;
using Entities;
using DataAccess.Abstract;
using DataAccess.Concrete;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class FridgeManager : IFridgeService
    {
        private IFridgeRepository _FridgeRepository;

        public FridgeManager()
        {
            _FridgeRepository = new FridgeRepository();
        }

        public Fridge CreateFridge(Fridge Fridge)
        {
            return _FridgeRepository.CreateFridge(Fridge);
        }

        public void DeleteFridge(int id)
        {
            _FridgeRepository.DeleteFridge(id);
        }

        public List<Fridge> GetAllFridges()
        {
            return _FridgeRepository.GetAllFridges();
        }

        public Fridge GetFridgeById(int id)
        {
            return _FridgeRepository.GetFridgeById(id);
        }

        public Fridge UpdateFridge(Fridge Fridge)
        {
            return _FridgeRepository.UpdateFridge(Fridge);
        }
    }
}
