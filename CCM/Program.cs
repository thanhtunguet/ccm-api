using System.Text.Json.Serialization;
using CCM.Models;
using CCM.Repositories;
using CCM.Services;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    DotEnv.Load();
}

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(
    options => { options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; }
);

builder.Services.AddScoped<CcmContext>();
// Repository and service injection for Bank
builder.Services.AddScoped<BankRepository>();
builder.Services.AddScoped<BankService>();
// Repository and service injection for CardClass
builder.Services.AddScoped<CardClassRepository>();
builder.Services.AddScoped<CardClassService>();
// Repository and service injection for Customer
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<CustomerService>();
// Repository and service injection for Store
builder.Services.AddScoped<StoreRepository>();
builder.Services.AddScoped<StoreService>();
// Repository and service injection for Card
builder.Services.AddScoped<CardRepository>();
builder.Services.AddScoped<CardService>();
// Repository and service injection for Transaction
builder.Services.AddScoped<TransactionRepository>();
builder.Services.AddScoped<TransactionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
