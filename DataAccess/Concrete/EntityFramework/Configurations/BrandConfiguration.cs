using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand")
                .HasKey(x=>x.BrandId)
                .HasName("pk_brands_id");
        }
    }

    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars")
                .HasKey(x => x.CarId)
                .HasName("pk_cars_id");

            builder.HasOne(typeof(Brand))
                .WithMany()
                .HasForeignKey()
                .HasConstraintName("fk_cars_branid");

        }
    }
}
/*

 */
// update-database