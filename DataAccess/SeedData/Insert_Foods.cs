using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;
using System.Collections.Generic;

namespace DataAccess.SeedData
{
    public class Insert_Foods : IEntityTypeConfiguration<Food>
    {
        public List<Food> Food_Data()
        {
            List<Food> list = new List<Food>();
            list.Add(new Food { id = 1, yemek_ismi = "Şeftali", gün_bozulma_tarihi = 15, protein_yüzde = 3, protein_gr = 30, yağ_yüzde = 0, yağ_gr = 0, karbonhidrat_yüzde = 1, karbonhidrat_gr = 20.8, kalori = 40, sodyum_gr = 0, potasyum_gr = 4, lif_gr = 9, kollestrol_gr = 0 });
            list.Add(new Food { id = 2, yemek_ismi = "Erik", gün_bozulma_tarihi = 10, protein_yüzde = 2, protein_gr = 10.5, yağ_yüzde = 0, yağ_gr = 0, karbonhidrat_yüzde = 2, karbonhidrat_gr = 30.2, kalori = 50, sodyum_gr = 0, potasyum_gr = 4, lif_gr = 3, kollestrol_gr = 4 });
            list.Add(new Food { id = 3, yemek_ismi = "Armut", gün_bozulma_tarihi = 5, protein_yüzde = 10, protein_gr = 15, yağ_yüzde = 1, yağ_gr = 5.1, karbonhidrat_yüzde = 1, karbonhidrat_gr = 5, kalori = 20, sodyum_gr = 1, potasyum_gr = 3, lif_gr = 1, kollestrol_gr = 0 });
            list.Add(new Food { id = 4, yemek_ismi = "Çilek", gün_bozulma_tarihi = 0, protein_yüzde = 15, protein_gr = 35, yağ_yüzde = 0, yağ_gr = 0, karbonhidrat_yüzde = 1, karbonhidrat_gr = 5, kalori = 15, sodyum_gr = 0.4, potasyum_gr = 0.1, lif_gr = 4, kollestrol_gr = 0 });
            //bozulma tarihi 0 olanlar test amaçlıdır. 5 dk içinde bildirim gönderilmektedir.
            return list;
        }

        public void Configure(EntityTypeBuilder<Food> entity)
        {
            entity.HasData(Food_Data());
        }
    }
}
