using Gameverse.Services;
using Gameverse.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<GameverseContext>("Data Source=GameverseDatabase.db");


// Add the PromotionsContext

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProductsService>();
builder.Services.AddScoped<ShoppingCartsService>();

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

app.CreateDbIfNotExists();

app.Run();
