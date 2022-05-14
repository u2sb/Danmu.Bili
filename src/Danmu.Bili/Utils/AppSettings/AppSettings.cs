namespace Danmu.Bili.Utils.AppSettings;

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
    public string[]? WithOrigins { get; set; }

    /// <summary>
    ///     直播跨域设置
    /// </summary>
    public string[]? LiveWithOrigins { get; set; }

    /// <summary>
    ///     Kestrel设置
    /// </summary>
    public KestrelSettings? KestrelSettings { get; set; }

    /// <summary>
    ///     BiliBili弹幕解析相关设置
    /// </summary>
    public BiliBiliSetting? BiliBiliSetting { get; set; }
}

/// <summary>
///     BiliBili弹幕解析相关设置
/// </summary>
public class BiliBiliSetting
{
    /// <summary>
    ///     Cid缓存时间 单位h
    /// </summary>
    public int CidCacheTime { get; set; } = int.MaxValue;

    /// <summary>
    ///     弹幕缓存时间 单位h
    /// </summary>
    public int DanmuCacheTime { get; set; } = 6;
}

/// <summary>
///     Kestrel设置
/// </summary>
public class KestrelSettings
{
    /// <summary>
    ///     监听地址
    /// </summary>
    public Dictionary<string, List<int>>? Listens { get; set; }

    /// <summary>
    ///     UnixSocketPath
    /// </summary>
    public List<string>? UnixSocketPath { get; set; }
}