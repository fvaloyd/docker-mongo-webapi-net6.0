using docker_mongo_webapi.databaseSetting;
using docker_mongo_webapi.services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// JSON serialization
builder.Services.AddControllers()
    .AddNewtonsoftJson(opt => opt.UseMemberCasing());
builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB Configuration
builder.Services.Configure<MongoDbSettings>(
        builder.Configuration.GetSection("MongoDbSettings"));

// Service
builder.Services.AddSingleton<PeliculaServices>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
