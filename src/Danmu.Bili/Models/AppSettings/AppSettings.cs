namespace Danmu.Bili.Models.AppSettings;

public class AppSettings
{
    public AppSettings()
    {
    }

    public AppSettings(IConfiguration configuration)
    {
        configuration.Bind(this);
    }

    /// <summary>
    ///     跨域设置
    /// </summary>
    public string[] WithOrigins { get; set; } = { };


    /// <summary>
    ///     BiliBili弹幕解析相关设置
    /// </summary>
    public BiliBiliSetting BiliBiliSetting { get; set; } = new();

    public DataBase DataBase { get; set; } = new();
}

/// <summary>
///     BiliBili弹幕解析相关设置
/// </summary>
public class BiliBiliSetting
{
    /// <summary>
    ///     Cid缓存时间 单位h
    /// </summary>
    public int PageCacheTime { get; set; } = 8640;

    /// <summary>
    ///     弹幕缓存时间 单位h
    /// </summary>
    public int DanmuCacheTime { get; set; } = 6;
}

public class DataBase
{
    public string DanmuCachingDb = "DanmuCaching.db";
    public string Directory = "DataBase";
}