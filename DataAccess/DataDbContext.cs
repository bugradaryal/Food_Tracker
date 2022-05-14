using Microsoft.EntityFrameworkCore;
using Entities;
using DataAccess.SeedData;
using System;

namespace DataAccess
{
    public class DataDbContext : DbContext
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
        public DbSet<User_article> User_articles { get; set; }



        //fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //////////////////User
            modelBuilder.Entity<User>().HasKey(x => x.id);
            modelBuilder.Entity<User>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().Property(x => x.Ad).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Soyad).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Eposta).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Eposta).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Sifre).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Cinsiyet).HasColumnType("varchar(15)").HasDefaultValue("Belirtmemiş");

            /////////////////////Fridges
            modelBuilder.Entity<Fridge>().HasKey(x => x.id);
            modelBuilder.Entity<Fridge>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Fridge>().Property(x => x.user_id).IsRequired();
            modelBuilder.Entity<Fridge>().Property(x => x.name).HasColumnType("varchar(15)").HasDefaultValue("Buzdolabım");

            /////////////////////My_Foods
            modelBuilder.Entity<My_Food>().HasKey(x => x.id);
            modelBuilder.Entity<My_Food>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<My_Food>().Property(x => x.Fridges_id).IsRequired();

            /////////////////////Foods
            modelBuilder.Entity<Food>().HasKey(x => x.id);
            modelBuilder.Entity<Food>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Food>().Property(x => x.yemek_ismi).HasColumnType("varchar(40)").IsRequired();
            modelBuilder.Entity<Food>().Property(x => x.protein_yüzde).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.yağ_yüzde).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.karbonhidrat_yüzde).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.kalori).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.protein_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.yağ_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.karbonhidrat_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.sodyum_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.potasyum_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.kalsiyum_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.lif_gr).HasDefaultValue(0);
            modelBuilder.Entity<Food>().Property(x => x.kollestrol_gr).HasDefaultValue(0);

            /////////////////////User_article
            modelBuilder.Entity<User_article>().HasKey(x => x.id);
            modelBuilder.Entity<User_article>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User_article>().Property(x => x.user_id).IsRequired();
            modelBuilder.Entity<User_article>().Property(x => x.title).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<User_article>().Property(x => x.date).HasColumnType("varchar(30)").HasDefaultValue(DateTime.Now.ToString("dd / MM / yyyy"));
            modelBuilder.Entity<User_article>().Property(x => x.title).HasColumnType("varchar(500)").IsRequired();  //max length 500

            /////////////////////Notification

            modelBuilder.Entity<Notification>().HasKey(x => x.id);
            modelBuilder.Entity<Notification>().Property(x => x.id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Notification>().Property(x => x.user_id).IsRequired();
            modelBuilder.Entity<Notification>().Property(x => x.tercih).HasColumnType("varchar(10)").HasDefaultValue("None");

            //add to database a food items
            modelBuilder.ApplyConfiguration(new Insert_Foods());


            // referances 

            modelBuilder.Entity<Fridge>().HasOne<User>(s => s.User).WithMany(g => g.Fridge).HasForeignKey(s => s.user_id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User_article>().HasOne<User>(s => s.User).WithMany(g => g.User_article).HasForeignKey(s => s.user_id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<My_Food>().HasOne<Fridge>(s => s.Fridge).WithMany(g => g.My_Food).HasForeignKey(s => s.Fridges_id).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<My_Food>().HasOne<Food>(s => s.Food).WithOne(g => g.My_Food).HasForeignKey<My_Food>(s => s.Foods_id).OnDelete(DeleteBehavior.Restrict); ;
            modelBuilder.Entity<Notification>().HasOne<User>(s => s.User).WithOne(g => g.Notification).HasForeignKey<Notification>(s => s.user_id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
