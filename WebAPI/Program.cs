using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using DataAccess.Concrete.EntityFramework;
using Entities.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

var builder = WebApplication.CreateBuilder(args);

#region DbOptions

IServiceCollection serviceCollection = builder.Services.AddDbContext<SchoolManagementDbContext>(opts => opts.UseSqlServer(
    "Data Source =(LocalDB)\\MSSQLLocalDB; Initial Catalog = SchoolManagementDb; Integrated Security = True",
    options => options.MigrationsAssembly("DataAccess").MigrationsHistoryTable(HistoryRepository.DefaultTableName, "dbo")
));

#endregion DbOptions

#region Dependency resolvers

// business
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                    .ConfigureContainer<ContainerBuilder>(builder =>
                    {
                        builder.RegisterModule(new AutofacBusinessModule());
                    });
// core
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

#endregion Dependency resolvers

#region AutoMapper

builder.Services.AddAutoMapper(typeof(MappingProfile));

#endregion AutoMapper

#region Custom Jwt

builder.Services.AddCustomJwtToken(builder.Configuration);

#endregion Custom Jwt


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

#region Exception Middleware

app.ConfigureCustomExceptionMiddleware();


#endregion Exception Middleware

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
