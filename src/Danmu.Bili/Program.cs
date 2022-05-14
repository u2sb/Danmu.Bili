using System.Net;
using System.Runtime.InteropServices;
using Danmu.Bili.Utils.AppSettings;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();

builder.WebHost.ConfigureAppConfiguration((context, configurationBuilder) =>
{
    var env = context.HostingEnvironment;
    configurationBuilder
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
    appSettings = configurationBuilder.Build().Get<AppSettings>();
}).ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions =>
    {
        var ks = appSettings.KestrelSettings;

        //如果是Linux平台
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            if (ks?.UnixSocketPath?.Count > 0)
                foreach (var path in ks.UnixSocketPath)
                {
                    if (File.Exists(path)) File.Delete(path);
                    serverOptions.ListenUnixSocket(path);
                }
        }
        if(ks?.Listens?.Count > 0)
            foreach (var listen in ks.Listens)
                if (IPAddress.TryParse(listen.Key, out var ip))
                    foreach (var port in listen.Value)
                        serverOptions.Listen(ip, port);
    });
});

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();