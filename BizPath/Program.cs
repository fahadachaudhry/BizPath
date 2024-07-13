using BizPath.Interfaces;
using BizPath.Services;
using RuleEngine.Interfaces;
using RuleEngine.RuleEngines;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBusinessWorkflowService, BusinessWorkflowService>();

builder.Services.AddScoped<IRuleEngineWorkflow, RestaurantWorkflow>();
builder.Services.AddScoped<IRuleEngineWorkflow, ServiceWorkflow>();
builder.Services.AddScoped<IRuleEngineWorkflow, StoreWorkflow>();
builder.Services.AddScoped<IRuleEngineWorkflow, WholesaleWorkflow>();

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
