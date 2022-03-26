using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities;

namespace DataAccess.Insert_Roles
{
    public  class Insert_Roles : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.HasData(new Role[] {
                new Role{Role_name="User"},
                new Role{Role_name="Author"},
                new Role{Role_name="Admin"},
            });
        }
    }
}
