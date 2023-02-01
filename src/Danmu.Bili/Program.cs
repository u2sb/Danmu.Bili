using System.Text.Json;
using Danmu.Bili.Models.AppSettings;
using Danmu.Bili.Utils.BiliBiliHelp;
using Danmu.Bili.Utils.Cache;
using FastEndpoints;
using Microsoft.AspNetCore.HttpOverrides;
using RestSharp;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();

if (!Directory.Exists(appSettings!.DataBase.Directory)) Directory.CreateDirectory(appSettings.DataBase.Directory);

// Add services to the container.
var services = builder.Services;

services.AddFastEndpoints();

// 转接头，代理
services.Configure<ForwardedHeadersOptions>(options =>
{
  options.ForwardedHeaders =
    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

//配置跨域
services.AddCors(options =>
{
  options.AddDefaultPolicy(policy =>
    policy.WithMethods("GET", "POST", "OPTIONS").SetIsOriginAllowedToAllowWildcardSubdomains()
      .WithOrigins(appSettings.WithOrigins).AllowAnyHeader());
});

//注册服务
services.AddSingleton<AppSettings>();
services.AddSingleton<DanMuCacheDbContext>();
services.AddSingleton(new RestClient(new HttpClient()));
services.AddScoped<BiliBiliHelp>();
services.AddScoped<PageCache>();
services.AddScoped<DanMuCache>();


var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseForwardedHeaders();
app.UseCors();
app.UseFastEndpoints(c =>
{
  c.Endpoints.RoutePrefix = "api";

  c.Serializer.Options.PropertyNameCaseInsensitive = true;
  c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

app.Run();