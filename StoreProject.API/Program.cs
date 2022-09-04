using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using StoreProject.API.ActionFilters;
using StoreProject.API.Extensions;
using StoreProject.Core.Domain.Base;
using StoreProject.Core.Domain.Logger;
using StoreProject.Infra.Data.Base;
using StoreProject.Infra.Data.Common;
using StoreProject.Infra.Data.Logger;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),
    "/nlog.config"));

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.Configure<IISOptions>(options => { });
builder.Services.AddScoped<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddScoped<ValidateProductCategoryExistsAttribute>();
builder.Services.AddScoped<ValidateProductExistsAttribute>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
});
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddDbContext<StoreDbContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"), b =>
        b.MigrationsAssembly("StoreProject.API")));

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NewsBack.API v1"));
}
else
{
    app.UseHsts();
}

void Configure(ILoggerManager logger) => app.ConfigureExceptionHandler(logger);

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
