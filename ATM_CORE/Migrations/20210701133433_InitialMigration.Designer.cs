// <auto-generated />
using System;
using ATM_CORE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ATM_CORE.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20210701133433_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ATM_CORE.Models.Cards", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CardNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberAttempts")
                        .HasColumnType("int");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("ATM_CORE.Models.Operations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("CardID")
                        .HasColumnType("int");

                    b.Property<int?>("CardsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOperacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CardsId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("ATM_CORE.Models.Operations", b =>
                {
                    b.HasOne("ATM_CORE.Models.Cards", null)
                        .WithMany("ListOperations")
                        .HasForeignKey("CardsId");
                });

            modelBuilder.Entity("ATM_CORE.Models.Cards", b =>
                {
                    b.Navigation("ListOperations");
                });
#pragma warning restore 612, 618
        }
    }
}
