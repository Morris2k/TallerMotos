using Microsoft.EntityFrameworkCore;
using TallerMotos.DAL;
using TallerMotos.Domain.Interfaces;
using TallerMotos.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Esta es la línea de code que necesito para configurar la conexión a la BD
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// contenedor de dependencias
builder.Services.AddScoped<iMotorcyclesServices, MotorcyclesServices>();
builder.Services.AddScoped<iBillServices, BillServices>();
builder.Services.AddScoped<iBuyServices, BuyServices>();
builder.Services.AddScoped<iClientServices, ClientServices>();
builder.Services.AddScoped<iEmployeeServices, EmployeeServices>();
builder.Services.AddScoped<iProductServices, ProductServices>();
builder.Services.AddScoped<iRepairServices, RepairServices>();
builder.Services.AddScoped<iServiceOrderServices, ServiceOrderServices>();
builder.Services.AddScoped<iUserServices, UserServices>();

builder.Services.AddTransient<SeederDB>();//Ciclo de vida del Seeder
builder.Services.AddScoped<iServiceTypeServices, ServiceTypeServices>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


//Configuración alimentador DB
SeederData();

void SeederData()
{
    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();
    
    using (IServiceScope? scope = scopeFactory.CreateScope())
    {
        SeederDB? service = scope.ServiceProvider.GetService<SeederDB>();
        service.SeederAsync().Wait();
    }
}

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
