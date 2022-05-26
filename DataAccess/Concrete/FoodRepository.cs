using DataAccess.Abstract;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete
{
    public class FoodRepository : IFoodRepository
    {
        public List<Food> GetAllFoods()
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Foods.ToList();
            }
        }

        public Food GetFoodById(int id)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Foods.Find(id);
            }
        }

        public List<Food> SearchByname(string name)
        {
            using (var DbContext = new DataDbContext())
            {
                return DbContext.Foods.Where(x => x.yemek_ismi.Contains(name)).ToList();
            }
        }

        public List<Food> Filter(List<Food>food, string islem)
        {
            using (var DbContext = new DataDbContext())
            {
                var data = GetAllFoods();
                switch (islem)
                {
                    case "Protein(%)": return data.OrderBy(x => x.protein_yüzde).ToList();
                    case "Protein(gr)": return data.OrderBy(x => x.protein_gr).ToList();
                    case "Yağ(%)": return data.OrderBy(x => x.yağ_yüzde).ToList();
                    case "Yağ(gr)": return data.OrderBy(x => x.yağ_gr).ToList();
                    case "Karbonhidrat(%)": return data.OrderBy(x => x.karbonhidrat_yüzde).ToList();
                    case "Karbonhidrat(gr)": return data.OrderBy(x => x.karbonhidrat_gr).ToList();
                    case "Kalori": return data.OrderBy(x => x.kalori).ToList();
                    case "Sodyum(gr)": return data.OrderBy(x => x.sodyum_gr).ToList();
                    case "Potasyum(gr)": return data.OrderBy(x => x.potasyum_gr).ToList();
                    case "Kalsiyum(gr)": return data.OrderBy(x => x.kalsiyum_gr).ToList();
                    case "Lif(gr)": return data.OrderBy(x => x.lif_gr).ToList();
                    case "Kollestrol(gr)": return data.OrderBy(x => x.kollestrol_gr).ToList();
                    case "Bozulma Süresi": return data.OrderBy(x => x.gün_bozulma_tarihi).ToList();
                    default: return data;
                }
            }
        }
    }
}
