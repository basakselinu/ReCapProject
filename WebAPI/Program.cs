using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

//Singleton(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void Singleton(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IBrandService, BrandManager>();
    builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

    builder.Services.AddSingleton<ICarService, CarManager>();
    builder.Services.AddSingleton<ICarDal, EfCarDal>();

    builder.Services.AddSingleton<IColorService, ColorManager>();
    builder.Services.AddSingleton<IColorDal, EfColorDal>();

    builder.Services.AddSingleton<ICustomerService, CustomerManager>();
    builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

    builder.Services.AddSingleton<IRentalService, RentalManager>();
    builder.Services.AddSingleton<IRentalDal, EfRentalDal>();

    builder.Services.AddSingleton<IUserService, UserManager>();
    builder.Services.AddSingleton<IUserDal, EfUserDal>();
}