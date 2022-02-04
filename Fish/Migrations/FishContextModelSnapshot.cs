﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fish.Migrations
{
    [DbContext(typeof(FishContext))]
    partial class FishContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("Fish.Models.Animal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CareLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenusID")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("MaxSize")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Photo")
                        .HasColumnType("TEXT");

                    b.Property<int>("Temparament")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("GenusID");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("Fish.Models.Family", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Family");
                });

            modelBuilder.Entity("Fish.Models.Genus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FamilyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FamilyId");

                    b.ToTable("Genus");
                });

            modelBuilder.Entity("Fish.Models.Animal", b =>
                {
                    b.HasOne("Fish.Models.Genus", "Genus")
                        .WithMany("Animals")
                        .HasForeignKey("GenusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genus");
                });

            modelBuilder.Entity("Fish.Models.Genus", b =>
                {
                    b.HasOne("Fish.Models.Family", "Family")
                        .WithMany("genera")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");
                });

            modelBuilder.Entity("Fish.Models.Family", b =>
                {
                    b.Navigation("genera");
                });

            modelBuilder.Entity("Fish.Models.Genus", b =>
                {
                    b.Navigation("Animals");
                });
#pragma warning restore 612, 618
        }
    }
}
