using Microsoft.EntityFrameworkCore;
using System;

namespace WheelzyTest.Model.EF
{
    public class WheelzyTestContext : DbContext
    {
        public WheelzyTestContext(DbContextOptions<WheelzyTestContext> options) : base(options)
        {
           
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase("MyDatabase");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definir status
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Pending" },
                new Status { Id = 2, Name = "Acceptance" },
                new Status { Id = 3, Name = "Accepted" },
                new Status { Id = 4, Name = "Picked Up" }
            );

            // Definir car y casos de venta de coche
            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Year = 1986, Make = "Volkswagen", Model = "1500", Submodel = "Rural", ZipCode = "1876" },
                new Car { Id = 2, Year = 2019, Make = "Renault", Model = "Kangoo", Submodel = "Stepway", ZipCode = "2201" }
            );

            modelBuilder.Entity<CarSaleCase>().HasData(
                new CarSaleCase { Id = 1, CarId = 1, CurrentStatusId = 1 },
                new CarSaleCase { Id = 2, CarId = 2, CurrentStatusId = 2 },
                new CarSaleCase { Id = 3, CarId = 1, CurrentStatusId = 3 },
                new CarSaleCase { Id = 4, CarId = 2, CurrentStatusId = 4 }
            );

            // Definir compradores
            modelBuilder.Entity<Buyer>().HasData(
                new Buyer { Id = 1, Name = "Walter Andreani", Quote = 15000.00m, IsCurrent = true, CarSaleCaseId = 1 },
                new Buyer { Id = 2, Name = "Esteban Diez", Quote = 18000.00m, IsCurrent = false, CarSaleCaseId = 1 },
                new Buyer { Id = 3, Name = "Patricia Etevez", Quote = 20000.00m, IsCurrent = true, CarSaleCaseId = 2 },
                new Buyer { Id = 4, Name = "Almendra Balboa", Quote = 17500.00m, IsCurrent = false, CarSaleCaseId = 2 }
            );

            // Definir historial de estados de caso
            modelBuilder.Entity<CaseStatus>().HasData(
                new CaseStatus { Id = 1, StatusId = 1, Date = null, ChangedBy = "Nelson" }, 
                new CaseStatus { Id = 2, StatusId = 2, Date = null, ChangedBy = "Matias" }, 
                new CaseStatus { Id = 3, StatusId = 3, Date = DateTime.Now.AddDays(-10), ChangedBy = "Admin" },
                new CaseStatus { Id = 4, StatusId = 4, Date = DateTime.Now, ChangedBy = "Driver" } 
            );

            modelBuilder.Entity<Order>().HasData(
             new Order { Id = 1, StatusId = 1, Date = DateTime.Now.AddDays(-100), CustomerId = 1, Active=true },
             new Order { Id = 2, StatusId = 2, Date = DateTime.Now, CustomerId = 1, Active = true },
             new Order { Id = 3, StatusId = 3, Date = DateTime.Now, CustomerId = 1, Active = false },
             new Order { Id = 4, StatusId = 2, Date = DateTime.Now, CustomerId = 1, Active = false },
             new Order { Id = 5, StatusId = 3, Date = DateTime.Now.AddDays(-10), CustomerId = 1, Active = true },
             new Order { Id = 6, StatusId = 4, Date = DateTime.Now, CustomerId = 2, Active = true } ,
             new Order { Id = 7, StatusId = 3, Date = DateTime.Now, CustomerId = 2, Active = false },
             new Order { Id = 8, StatusId = 3, Date = DateTime.Now, CustomerId = 2, Active = false },
             new Order { Id = 9, StatusId = 5, Date = DateTime.Now, CustomerId = 3, Active = false },
             new Order { Id = 10, StatusId = 3, Date = DateTime.Now, CustomerId = 3, Active = true },
             new Order { Id = 11, StatusId = 3, Date = DateTime.Now, CustomerId = 3, Active = false }
         );



            modelBuilder.Entity<Customer>().HasData(
    new Customer { Id = 1, Name = "Gabriel", Balance = 10 },
    new Customer { Id = 2, Name = "Matias", Balance = 73 },
    new Customer { Id = 3, Name = "Adrian", Balance = 24 }
);
        }
        public DbSet<Status> Status { get; set; }
        public DbSet<CaseStatus> CaseStatus { get; set; }
        public DbSet<CarSaleCase> CarSaleCase { get; set; }
        public DbSet<Buyer> Buyer { get; set; }
        public DbSet<Car> Car { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Customer> Customers { get; set; }
        
    }
}
