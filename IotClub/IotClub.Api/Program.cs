using IotClub.Libraries.CentralUnits.Repositories;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<ICentralUnitRepository, CosmosCentralUnitRepository>();

//AppConfig
string appConfigConnectionString = builder.Configuration.GetConnectionString("IotClub:Dev:AppConfiguration");
builder.Configuration.AddAzureAppConfiguration(appConfigConnectionString);

//Cosmos
var cosmosConnectionString = builder.Configuration.GetConnectionString("IotClub:Dev:Cosmos");
var cosmosClientOptions = new CosmosClientOptions
{
    SerializerOptions = new CosmosSerializationOptions()
    {
        IgnoreNullValues = true,
        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
    }
};
builder.Services.AddSingleton<CosmosClient>(new CosmosClient(cosmosConnectionString, cosmosClientOptions));


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
