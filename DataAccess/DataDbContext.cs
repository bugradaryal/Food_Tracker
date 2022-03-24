using Microsoft.EntityFrameworkCore;
using Entities;


namespace DataAccess
{
    public class DataDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Database connection string - connection bağlantısı
            optionsBuilder.UseSqlServer("Server=.\\SQLExpress; Database=yemek_takip; uid=sa; pwd=12345678;");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Fridge> Fridges { get; set; }
        public DbSet<My_Food> My_Foods { get; set; }
        public DbSet<User> Users { get; set; }

        //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //////////////////User
            //id
            modelBuilder.Entity<User>().HasKey(x => x.id);
            modelBuilder.Entity<User>().Property(x => x.id).ValueGeneratedOnAdd();
            //ad
            modelBuilder.Entity<User>().Property(x => x.Ad).HasColumnType("varchar(30)").IsRequired();
            //Soyad
            modelBuilder.Entity<User>().Property(x => x.Soyad).HasColumnType("varchar(30)").IsRequired();
            //Eposta
            modelBuilder.Entity<User>().Property(x => x.Eposta).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().HasIndex(u => u.Eposta).IsUnique();
            //Sifre
            modelBuilder.Entity<User>().Property(x => x.Sifre).HasColumnType("varchar(30)").IsRequired();
            //referanslar
            modelBuilder.Entity<User>().Property(x => x.Sifre).HasColumnType("varchar(30)").IsRequired();
            /////////////////////Food
            //id
            modelBuilder.Entity<Food>().HasKey(x => x.id);
            modelBuilder.Entity<Food>().Property(x => x.id).ValueGeneratedOnAdd();
            //yemek_ismi
            modelBuilder.Entity<Food>().Property(x => x.yemek_ismi).HasColumnType("varchar(40)").IsRequired();
            /////////////////////Fridges
            //id
            modelBuilder.Entity<Fridge>().HasKey(x => x.id);
            modelBuilder.Entity<Fridge>().Property(x => x.id).ValueGeneratedNever();
            //buzdolabı_id
            modelBuilder.Entity<Fridge>().Property(x => x.buzdolabı_id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Fridge>().HasIndex(u => u.buzdolabı_id).IsUnique();
            /////////////////////My_Foods
            //id
            modelBuilder.Entity<My_Food>().HasKey(x => x.id);
            modelBuilder.Entity<My_Food>().Property(x => x.id).ValueGeneratedOnAdd();

            /*************************************************** REFERANSLAR */

            modelBuilder.Entity<Fridge>().HasOne(x => x.User).WithMany(y => y.Fridge).HasForeignKey(y => y.id).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<My_Food>().HasOne(x => x.Fridge).WithMany(y => y.My_Food).HasForeignKey(y => y.id);

            modelBuilder.Entity<Food>().HasOne(x => x.My_Food).WithOne(y => y.Food).HasForeignKey<My_Food>(x => x.yemek_no);
        }
    }
}
