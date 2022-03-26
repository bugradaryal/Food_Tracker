using Entities;
using System.Collections.Generic;


namespace DataAccess.Abstract
{
    public interface IFridgeRepository
    {
        List<Fridge> GetAllFridges();
        Fridge GetFridgeById(int id);
        Fridge CreateFridge(Fridge Fridge);
        Fridge UpdateFridge(Fridge Fridge);
        void DeleteFridge(int id);
    }
}
