using banca_finanzas_net.DIP;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ***************************************************************************************
// Conexión hacia la base de datos.
builder.Services.AddPostgreSQLConnection(builder.Configuration);
// ***************************************************************************************

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// *************************************************************************************************
// Configuración para CORS.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   // .SetPreflightMaxAge(TimeSpan.FromHours(1)); // Cacheo de preflight por 1 hora
                   ;
        });
});
// *************************************************************************************************

// ******************************************************************************************
// *** All Services Dependency Injection ****************************************************
builder.Services.AddServicesDIP(builder.Configuration);
// ******************************************************************************************

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
