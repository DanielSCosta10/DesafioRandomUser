using Microsoft.Extensions.FileProviders;
using WebApi.Data;
using WebApi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()   
               .AllowAnyMethod()  
               .AllowAnyHeader();  
    });
});

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddHttpClient<RandomUserService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "WebUsers")),
    RequestPath = ""
});
app.UseRouting();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();
