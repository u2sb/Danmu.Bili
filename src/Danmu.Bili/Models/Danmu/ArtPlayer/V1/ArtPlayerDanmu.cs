using Bilibili.Community.Service.Dm.V1;

namespace Danmu.Bili.Models.Danmu.ArtPlayer.V1;

public class ArtPlayerDanmu
{
    /// <summary>
    ///     弹幕文本
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    ///     弹幕时间
    /// </summary>
    public float Time { get; set; }

    /// <summary>
    ///     弹幕颜色
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    ///     弹幕字号
    /// </summary>
    public int Size { get; set; } = 25;

    /// <summary>
    ///     是否有边框
    /// </summary>
    public bool Border { get; set; } = false;

    /// <summary>
    ///     弹幕模式 0-滚动 1-固定
    /// </summary>
    public int Mode { get; set; }


    public static explicit operator ArtPlayerDanmu(DanmakuElem data)
    {
        var t = data.Mode;
        switch (t)
        {
            case 4:
                t = 1;
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

        return new ArtPlayerDanmu
        {
            Time = data.Progress / 1000f,
            Mode = t,
            Color = $"#{data.Color:X}",
            Size = data.Fontsize,
            Text = data.Content
        };
    }
}