using Bilibili.Community.Service.Dm.V1;

namespace Danmu.Bili.Models.Danmu.Dplayer.V3;

public class DplayerDanmu
{
    /// <summary>
    ///     弹幕时间
    /// </summary>
    public float Time { get; set; }

    /// <summary>
    ///     弹幕类型
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    ///     弹幕颜色
    /// </summary>
    public uint Color { get; set; }

    /// <summary>
    ///     弹幕作者
    /// </summary>
    public string? Author { get; set; }

    /// <summary>
    ///     弹幕文字
    /// </summary>
    public string? Text { get; set; }

    public static explicit operator DplayerDanmu(DanmakuElem data)
    {
        var t = data.Mode;
        switch (t)
        {
            case 4:
                t = 2;
                break;
            case 5:
                t = 1;
                break;
            case 7:
                t = 0;
                data.Content = data.Content.Split(",")[4];
                break;
            case 8:
                t = 0;
                data.Content = null;
                break;
            default:
                t = 0;
                break;
        }

        return new DplayerDanmu
        {
            Time = data.Progress / 1000f,
            Type = t,
            Color = data.Color,
            Author = data.MidHash,
            Text = data.Content
        };
    }
}