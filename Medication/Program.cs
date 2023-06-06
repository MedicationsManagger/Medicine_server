using Entites;
using Medication;
using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ISystemMessageRepository, SystemMessagesRepository>();
builder.Services.AddScoped<ISystemMessageService, SystemMessageService>();

builder.Services.AddScoped<IMedicineStockRepository, MedicineStockRepository>();
builder.Services.AddScoped<IMedicineStockService, MedicineStockService>();

builder.Services.AddScoped<ITakingMedicationRepository, TakingMedicationRepository>();
builder.Services.AddScoped<ITakingMedicationService, TakingMedicationService>();

builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
builder.Services.AddScoped<IMeasurementService, MeasurementService>(); 

builder.Services.AddScoped<IMedicineForUserRepository, MedicineForUserRepository>();
builder.Services.AddScoped<IMedicineForUserService, MedicineForUserService>();

builder.Services.AddScoped<IMedicineRepository, MedicineRepository>();
builder.Services.AddScoped<IMedicineService, MedicineService>();

builder.Services.AddDbContext<MedicationsContext>(option => option.UseSqlServer(builder.Configuration.GetValue<String>("connectionString")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod()
      .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
