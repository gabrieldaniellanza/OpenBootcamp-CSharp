var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 1. LOCALIZACION
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. IDIOMAS SOPORTADOS

var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" }; // ingles de EEUU, espa�ol de espa�a, frances

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

// 3. ADD LOCATIZATION TO APP
app.UseRequestLocalization(localizationOptions);

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
