using Entities;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IFridgeService
    {
        List<Fridge> GetAllFridges();
        Fridge GetFridgeById(int id);
        Fridge CreateFridge(Fridge Fridge);
        Fridge UpdateFridge(Fridge Fridge);
        void DeleteFridge(int id);
    }
}
