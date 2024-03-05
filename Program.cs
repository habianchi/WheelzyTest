using Microsoft.EntityFrameworkCore;
using WheelzyTest.Model.EF;
using WheelzyTest.Services;
using Microsoft.Extensions.Logging;
using WheelzyTest.Model;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<WheelzyTestContext>(options =>
{
    options.UseInMemoryDatabase("WheelzyTest")
  // options.UseSqlServer(builder.Configuration.GetConnectionString("WheelzyTestConnection"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
    .EnableSensitiveDataLogging(); ;
});


var serviceProvider = builder.Services.BuildServiceProvider();
using (var scope = serviceProvider.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<WheelzyTestContext>();

    // Agregar datos de ejemplo a la base de datos en memoria
    context.Status.AddRange(
        new Status { Id = 1, Name = "Pending" },
        new Status { Id = 2, Name = "Acceptance" },
        new Status { Id = 3, Name = "Accepted" },
        new Status { Id = 4, Name = "Picked Up" }
    );

    context.Car.AddRange(
        new Car { Id = 1, Year = 1986, Make = "Volkswagen", Model = "1500", Submodel = "Rural", ZipCode = "1876" },
        new Car { Id = 2, Year = 2019, Make = "Renault", Model = "Kangoo", Submodel = "Stepway", ZipCode = "2201" }
    );

    context.CarSaleCase.AddRange(
        new CarSaleCase { Id = 1, CarId = 1, CurrentStatusId = 1 },
        new CarSaleCase { Id = 2, CarId = 2, CurrentStatusId = 2 },
        new CarSaleCase { Id = 3, CarId = 1, CurrentStatusId = 3 },
        new CarSaleCase { Id = 4, CarId = 2, CurrentStatusId = 4 }
    );

    context.Buyer.AddRange(
        new Buyer { Id = 1, Name = "Walter Andreani", Quote = 15000.00m, IsCurrent = true, CarSaleCaseId = 4 },
        new Buyer { Id = 2, Name = "Esteban Diez", Quote = 18000.00m, IsCurrent = false, CarSaleCaseId = 1 },
        new Buyer { Id = 3, Name = "Patricia Etevez", Quote = 20000.00m, IsCurrent = true, CarSaleCaseId = 2 },
        new Buyer { Id = 4, Name = "Almendra Balboa", Quote = 17500.00m, IsCurrent = false, CarSaleCaseId = 2 }
    );

    context.CaseStatus.AddRange(
        new CaseStatus { Id = 1, StatusId = 1, Date = null, ChangedBy = "Nelson" },
        new CaseStatus { Id = 2, StatusId = 2, Date = null, ChangedBy = "Matias" },
        new CaseStatus { Id = 3, StatusId = 3, Date = DateTime.Now.AddDays(-10), ChangedBy = "Admin" },
        new CaseStatus { Id = 4, StatusId = 4, Date = DateTime.Now, ChangedBy = "Driver" }
    );

    context.Order.AddRange(
        new Order { Id = 1, StatusId = 1, Date = DateTime.Now.AddDays(-100), CustomerId = 1, Active = true },
        new Order { Id = 2, StatusId = 2, Date = DateTime.Now, CustomerId = 1, Active = true },
        new Order { Id = 3, StatusId = 3, Date = DateTime.Now, CustomerId = 1, Active = false },
        new Order { Id = 4, StatusId = 2, Date = DateTime.Now, CustomerId = 1, Active = false },
        new Order { Id = 5, StatusId = 3, Date = DateTime.Now.AddDays(-10), CustomerId = 1, Active = true },
        new Order { Id = 6, StatusId = 4, Date = DateTime.Now, CustomerId = 2, Active = true },
        new Order { Id = 7, StatusId = 3, Date = DateTime.Now, CustomerId = 2, Active = false },
        new Order { Id = 8, StatusId = 3, Date = DateTime.Now, CustomerId = 2, Active = false },
        new Order { Id = 9, StatusId = 5, Date = DateTime.Now, CustomerId = 3, Active = false },
        new Order { Id = 10, StatusId = 3, Date = DateTime.Now, CustomerId = 3, Active = true },
        new Order { Id = 11, StatusId = 3, Date = DateTime.Now, CustomerId = 3, Active = false }
    );

    context.Customers.AddRange(
        new Customer { Id = 1, Name = "Gabriel", Balance = 10 },
        new Customer { Id = 2, Name = "Matias", Balance = 73 },
        new Customer { Id = 3, Name = "Adrian", Balance = 24 }
    );

    context.SaveChanges();
}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

