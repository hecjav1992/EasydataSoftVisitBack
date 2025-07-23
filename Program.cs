
var builder = WebApplication.CreateBuilder(args);

// Puerto para Render (Render escucha en el 80 por defecto)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(80);
});

// Servicios
builder.Services.AddHttpClient("GoogleMaps");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS para desarrollo y producción
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "https://easydatasoftvisitfront.onrender.com",
                "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials(); // Solo si usas cookies o auth headers
        });
});

var app = builder.Build();

// Archivos estáticos y página por defecto (útil si integras Angular en el mismo proyecto)
app.UseDefaultFiles();
app.UseStaticFiles();

// Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// No usar HTTPS redirection dentro del contenedor de Render
// Render ya maneja HTTPS externamente
// app.UseHttpsRedirection();

// CORS debe ir antes de Authorization y MapControllers
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

// Fallback para SPA (opcional si usas Angular desde otra URL)
app.MapFallbackToFile("/index.html");

app.Run();
