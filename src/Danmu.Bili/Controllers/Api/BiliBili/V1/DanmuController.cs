using Bilibili.Community.Service.Dm.V1;
using Danmu.Bili.Controllers.Api.Base;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Models.WebResults;
using Danmu.Bili.Utils.BiliBiliHelp;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.BiliBili.V1;

[Route("/api/bilibili/")]
[Route("/api/bilibili/v1/")]
public class DanmuController : BiliBiliBaseController
{
    public DanmuController(BiliBiliHelp bilibili) : base(bilibili)
    {
    }

    [HttpGet]
    [HttpGet("{id}/{p:int?}")]
    public async Task<WebResult<IEnumerable<DanmakuElem>?>> GetDanmu([FromQuery] BiliBiliQuery query, string? id,
        int p = 1)
    {
        var danmu = await Bilibili.GetDanmuAsync(query, id, p);
        return new WebResult<IEnumerable<DanmakuElem>?>(danmu?.Elems);
    }

    [HttpGet("raw")]
    [HttpGet("raw/{id}/{p:int?}")]
    public async Task<DmSegMobileReply?> GetDanmuRaw([FromQuery] BiliBiliQuery query, string? id, int p = 1)
    {
        var danmu = await Bilibili.GetDanmuAsync(query, id, p);
        return danmu;
    }
}