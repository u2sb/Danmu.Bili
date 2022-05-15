using Danmu.Bili.Controllers.Api.Base;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Models.WebResults.Dplayer.V3;
using Danmu.Bili.Utils.BiliBiliHelp;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.Danmu.Dplayer.V3;

[Route("/api/danmu/dplayer/")]
[Route("/api/danmu/dplayer/v1/")]
[Route("/api/danmu/dplayer/v2/")]
[Route("/api/danmu/dplayer/v3/")]
public class DplayerDanmuController : BiliBiliBaseController
{
    public DplayerDanmuController(BiliBiliHelp bilibili) : base(bilibili)
    {
    }

    [HttpGet]
    [HttpGet("{id}/{p:int?}")]
    public async Task<DplayerWebResult> Get([FromQuery] BiliBiliQuery query, string? id , int p = 1)
    {
        var danmu = await Bilibili.GetDanmuAsync(query, id, p);
        return new DplayerWebResult(danmu?.Elems);
    }
}