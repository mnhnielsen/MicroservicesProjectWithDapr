using Microsoft.EntityFrameworkCore;
using sample.microservice.catalog.Data;

var builder = WebApplication.CreateBuilder(args);

var jsonOpt = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true,
};

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddDbContext<ProductContext>(options =>
{
    options.UseCosmos(
        "URL",
        "KEY",
        "state"
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//For testing only
//string Endpoint = Environment.GetEnvironmentVariable("COSMOS_ENDPOINT") ?? string.Empty;
//string Key = Environment.GetEnvironmentVariable("COSMOS_KEY") ?? string.Empty;

//var options = new DbContextOptionsBuilder<ProductContext>().UseCosmos(Endpoint, Key, nameof(ProductContext)).Options;
//await ProductContext.CheckAndSeedDatabaseAsync(options);


//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCloudEvents();

app.MapControllers();

app.MapSubscribeHandler();

app.Run();
