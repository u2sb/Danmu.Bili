using Danmu.Bili.Controllers.Api.Base;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Utils.BiliBili;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.BiliBili.V1;

[Route("/api/bilibili/v1/")]
public class BiliBiliDanMuController : BiliBiliDanMuBaseController
{
  public BiliBiliDanMuController(BiliBiliHelp bilibili) : base(bilibili)
  {
  }

  [HttpGet("{bvid}")]
  [HttpGet("{bvid}/{p:int}")]
  [HttpGet("{bvid}.xml")]
  [HttpGet("{bvid}/{p:int}.xml")]
  public async Task<OldBiliBiliDanMu?> GetXmlDanMu(string bvid, int p = 1)
  {
    Response.ContentType = "text/xml";
    var a = await Bilibili.GetDanMuAsync(bvid, p);
    return (OldBiliBiliDanMu)a?.Elems;
  }

  [HttpGet]
  public async Task<OldBiliBiliDanMu?> GetDanXmlMuFromQuery([FromQuery] string? bvid, [FromQuery] int p = 1)
  {
    if (string.IsNullOrWhiteSpace(bvid))
    {
      Response.ContentType = "text/xml";
      return new OldBiliBiliDanMu();
    }

    return await GetXmlDanMu(bvid, p);
  }
}