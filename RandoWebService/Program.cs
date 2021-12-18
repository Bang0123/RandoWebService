using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using RandoWebService.Data;
using RandoWebService.Shared;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" }));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();
}
builder.Services.AddDbContext<GlobalEliteContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString(Constants.GLOBAL_ELITE_CONTEXT)));

// Request pipeline
var app = builder.Build();

using var scope = app.Services.CreateAsyncScope();
var ctx = scope.ServiceProvider.GetRequiredService<GlobalEliteContext>();
// Seeeeder.Initialize(ctx);

if (!await ctx.Database.EnsureCreatedAsync())
{
    throw new Exception("Database existance could not be ensured");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = "api";
    });
    app.UseDeveloperExceptionPage();
    app.UseCors(builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
        builder.Build();
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

const string cacheMaxAge = "604800";
app.UseDefaultFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "elite-gang/build")),
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
             "Cache-Control", $"public, max-age={cacheMaxAge}");
    }
});

app.UseAuthorization();

app.MapControllers();
app.UseRouting();


await app.RunAsync();