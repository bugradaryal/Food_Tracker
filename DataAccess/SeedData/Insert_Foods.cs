using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace DataAccess.SeedData
{
    public class Insert_Foods : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> entity)
        {
            entity.HasData(new Food[] {
                new Food{id=1, yemek_ismi="Elma"},
                new Food{id=2, yemek_ismi="Erik"},
                new Food{id=3, yemek_ismi="Kiraz"},
            });
        }
    }
}
