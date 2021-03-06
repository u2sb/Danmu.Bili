namespace Danmu.Bili.Models.BiliBili;

public class BiliBiliQuery
{
    public int Aid { get; set; } = 0;
    public string Bvid { get; set; } = string.Empty;
    public int P { get; set; } = 1;

    /// <summary>
    /// 类型 1视频 2漫画
    /// </summary>
    public int Type { get; set; } = 1;
}