using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MapExplore.Models;

namespace MapExplore.Migrations
{
    [DbContext(typeof(MapExploreDbContext))]
    [Migration("20170301232323_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MapExplore.Models.Brewery", b =>
                {
                    b.Property<int>("BreweryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Lat");

                    b.Property<string>("Long");

                    b.Property<string>("Name");

                    b.HasKey("BreweryId");

                    b.ToTable("Breweries");
                });
        }
    }
}
