using backend.Data;
using backend.Helpers;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

// Add services to the container.
// builder.Services.AddDbContext<DDFinanceContext>(
//     options => {options.UseSqlServer(builder.Configuration.GetConnectionString("DDFinanceMainDb"),
//     sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
//         maxRetryCount:5,
//         maxRetryDelay:TimeSpan.FromSeconds(30),
//         errorNumbersToAdd: null)  
//                )
//                 .EnableSensitiveDataLogging()
//                 .LogTo(Console.WriteLine);
// });

builder.Services.AddDbContext<DDFinanceContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DDFinancePostgresDb"))
);

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<InsuranceInterface,InsuranceRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();

app.UseCors(options => 
{
    options.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();

});

app.UseRouting();


app.MapControllers();


app.Run();


