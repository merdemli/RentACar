using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class RentACarContext:DbContext  //DbContext oldugunu tanımlar,base sınıf,EF nuget ile gelir
    {
        //Context: DB tabloları ile proje classlarını bağlar,ilişkilendirir

        //virtual metot
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentACar;Trusted_Connection=true"); //veritabanının yeri 
        }

        public DbSet<Car> Cars { get; set; }   //hangi tabloya hangi class karşılık gelir
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
    }
}
