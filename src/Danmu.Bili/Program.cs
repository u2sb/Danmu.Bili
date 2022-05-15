using System.Text.Json;
using Danmu.Bili.Models.AppSettings;
using Danmu.Bili.Models.Converters;
using Danmu.Bili.Utils.BiliBiliHelp;
using Danmu.Bili.Utils.Cache;
using EasyCaching.LiteDB;
using Flurl.Http.Configuration;
using LiteDB;
using Microsoft.AspNetCore.HttpOverrides;
using static Danmu.Bili.Utils.Globals.VariableDictionary;

var builder = WebApplication.CreateBuilder(args);

var appSettings = builder.Configuration.Get<AppSettings>();

if (!Directory.Exists(appSettings.DataBase.Directory)) Directory.CreateDirectory(appSettings.DataBase.Directory);

// Add services to the container.
var services = builder.Services;


services.AddControllers();

//自定义序列化程序
services.AddControllers().AddXmlSerializerFormatters().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    opt.JsonSerializerOptions.Converters.Add(new IpAddressConverter());
});

// 配置弹幕缓存数据库
services.AddEasyCaching(options =>
{
    //use memory cache
    options.UseLiteDB(config =>
    {
        config.DBConfig = new LiteDBDBOptions
        {
            ConnectionType = ConnectionType.Direct,
            FilePath = appSettings.DataBase.Directory,
            FileName = appSettings.DataBase.DanmuCachingDb
        };
    }, BiliBiliDanmuCacheLiteDb);
});

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
services.AddSingleton<CacheLiteDb>();
services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
services.AddScoped<BiliBiliHelp>();




var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseForwardedHeaders();
app.UseCors();
app.UseResponseCaching();
app.MapControllers();

app.Run();