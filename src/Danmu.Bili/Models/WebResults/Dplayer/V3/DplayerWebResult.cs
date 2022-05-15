using System.Web;
using Bilibili.Community.Service.Dm.V1;
using Danmu.Bili.Models.Danmu.Dplayer.V3;

namespace Danmu.Bili.Models.WebResults.Dplayer.V3;

/// <summary>
///     Dplayer V3 弹幕返回数据
/// </summary>
public class DplayerWebResult : WebResult<object[][]>
{
    public DplayerWebResult()
    {
    }

    public DplayerWebResult(int code) : base(code)
    {
    }

    public DplayerWebResult(IEnumerable<DanmakuElem>? elems) : this(0)
    {
        Data = elems?.Select(s =>
        {
            var d = (DplayerDanmu) s;
            return new object[]
            {
                d.Time,
                d.Type,
                d.Color,
                string.IsNullOrWhiteSpace(d.Author) ? "" : HttpUtility.HtmlEncode(d.Author),
                string.IsNullOrWhiteSpace(d.Text) ? "" : HttpUtility.HtmlEncode(d.Text)
            };
        }).ToArray();
    }
}