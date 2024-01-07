using Microsoft.EntityFrameworkCore;
using PRODUCT.Context;
using PRODUCT.DataAccess.UnitOfWork;
using PRODUCT.DataAccess;
using PRODUCT.BusinessLayer;
using PRODUCT.Entities;
using PRODUCT.DataAccess.Repository;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using PRODUCT.Services.Interfaces;
using PRODUCT.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.mbenayed.json")
                            .Build();

Console.WriteLine(builder.Configuration.GetValue<string>("hello"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(Options => {
    Options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddHealthChecks();

builder.Services.AddCors(Options => {
    Options.AddPolicy("EnableCors", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddHealthChecks();

builder.Services.AddDbContext<ProductDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlStore")));

//Injections
// services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ProductDBContext>();

// Service

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IQRCodeService, QRCodeService>();

// BLL
builder.Services.AddScoped<IGenericBLL<Product>, GenericBLL<Product>>();

// repository
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

// Enable Cors
builder.Services.AddCors();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRODUCT", Version = "v1" });

});


// Add MVC services to the services container.
builder.Services.AddMvc()
    .AddNewtonsoftJson(opts =>
    {
        // Force Camel Case to JSON
        opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    });

//Json Serialisation Prov
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
});


//app.UseHttpsRedirection();
var app = builder.Build();

ApplyMigrations(app);


static void ApplyMigrations(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ProductDBContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("EnableCors");
app.UseAuthentication();

app.UseExceptionHandler(
  builder =>
  {
      builder.Run(
        async context  =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            context.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, PATCH");

            var error = context.Features.Get<IExceptionHandlerFeature>();
            if (error != null)
            {
                //context.Response.AddApplicationError(error.Error.Message);

                //await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
            }
        });
  });
//app.UseMvc(routes =>
//{
//    routes.MapRoute(
//        name: "default",
//        template: "{controller=User}/{action=Get}/{id?}");

//    // Uncomment the following line to add a route for porting Web API 2 controllers.
//    //routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
//});

app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();

app.MapControllers();
app.UseMvc(routes =>
{
    routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
});
/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});*/
app.Run();