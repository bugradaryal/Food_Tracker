﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("kalori")
                        .HasColumnType("int");

                    b.Property<int>("kalsiyum_gr")
                        .HasColumnType("int");

                    b.Property<int>("karbonhidrat_gr")
                        .HasColumnType("int");

                    b.Property<int>("karbonhidrat_yüzde")
                        .HasColumnType("int");

                    b.Property<int>("kollestrol_gr")
                        .HasColumnType("int");

                    b.Property<int>("lif_gr")
                        .HasColumnType("int");

                    b.Property<int>("potasyum_gr")
                        .HasColumnType("int");

                    b.Property<int>("protein_gr")
                        .HasColumnType("int");

                    b.Property<int>("protein_yüzde")
                        .HasColumnType("int");

                    b.Property<int>("sodyum_gr")
                        .HasColumnType("int");

                    b.Property<int>("yağ_gr")
                        .HasColumnType("int");

                    b.Property<int>("yağ_yüzde")
                        .HasColumnType("int");

                    b.Property<string>("yemek_ismi")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("id");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Entities.Fridge", b =>
                {
                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("buzdolabı_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("id");

                    b.HasIndex("buzdolabı_id")
                        .IsUnique();

                    b.ToTable("Fridges");
                });

            modelBuilder.Entity("Entities.My_Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("yemek_no")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("yemek_no")
                        .IsUnique();

                    b.ToTable("My_Foods");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("id");

                    b.HasIndex("Eposta")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entities.Fridge", b =>
                {
                    b.HasOne("Entities.User", "User")
                        .WithMany("Fridge")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.My_Food", b =>
                {
                    b.HasOne("Entities.Fridge", "Fridge")
                        .WithMany("My_Food")
                        .HasForeignKey("id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Food", "Food")
                        .WithOne("My_Food")
                        .HasForeignKey("Entities.My_Food", "yemek_no")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Fridge");
                });

            modelBuilder.Entity("Entities.Food", b =>
                {
                    b.Navigation("My_Food");
                });

            modelBuilder.Entity("Entities.Fridge", b =>
                {
                    b.Navigation("My_Food");
                });

            modelBuilder.Entity("Entities.User", b =>
                {
                    b.Navigation("Fridge");
                });
#pragma warning restore 612, 618
        }
    }
}
