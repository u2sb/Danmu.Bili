using Danmu.Bili.Controllers.Api.Base;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Models.Danmu.ArtPlayer.V1;
using Danmu.Bili.Models.Danmu.BiliBili;
using Danmu.Bili.Models.WebResults;
using Danmu.Bili.Utils.BiliBiliHelp;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.Danmu.ArtPlayer.V1;

[Route("/api/danmu/artplayer/")]
[Route("/api/danmu/artplayer/v1/")]
public class ArtPlayerDanmuController : BiliBiliBaseController
{
    public ArtPlayerDanmuController(BiliBiliHelp bilibili) : base(bilibili)
    {
    }

    [HttpGet]
    [HttpGet(".{format?}")]
    [HttpGet("{id}.{format?}")]
    [HttpGet("{id}/{p:int}.{format?}")]
    public async Task<dynamic> Get([FromQuery] BiliBiliQuery query, string? id, int p = 1, string? format = "xml")
    {
        var danmu = await Bilibili.GetDanmuAsync(query, id, p);
        if (!string.IsNullOrEmpty(format) && format.Equals("json"))
            return new WebResult<IEnumerable<ArtPlayerDanmu>?>(danmu?.Elems?.Select(s => (ArtPlayerDanmu) s));
        if (string.IsNullOrEmpty(format) || format == "xml") HttpContext.Request.Headers["Accept"] = "application/xml";
        return (OldBiliBiliDanmu) danmu?.Elems;
    }
}