using Danmu.Bili.Controllers.Api.Base;
using Danmu.Bili.Models.BiliBili;
using DanMu.Bili.Models.Protos.BiliBili.Dm;
using Danmu.Bili.Utils.BiliBili;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.BiliBili.V2;

[Route("/api/bilibili/")]
[Route("/api/bilibili/v2/")]
public class BiliBiliDanMuController : BiliBiliDanMuBaseController
{
  public BiliBiliDanMuController(BiliBiliHelp bilibili) : base(bilibili)
  {
  }

  [HttpGet]
  public async Task<Stream?> GetProtobufDanMuFromQueryAsync(string? bvid, int p = 1)
  {
    if (string.IsNullOrWhiteSpace(bvid)) return Stream.Null;
    return await GetProtobufDanMuAsync(bvid, p);
  }

  [HttpGet("{bvid}")]
  [HttpGet("{bvid}/{p:int}")]
  public async Task<Stream?> GetProtobufDanMuAsync(string bvid, int p = 1)
  {
    Response.ContentType = "application/x-protobuf";
    return await Bilibili.GetDanMuStreamAsync(bvid, p);
  }

  [HttpGet("{bvid}.json")]
  [HttpGet("{bvid}/{p:int}.json")]
  public async Task<DmSegMobileReply?> GetJsonDanMuAsync(string bvid, int p = 1)
  {
    Response.ContentType = "application/json";
    var a = await Bilibili.GetDanMuAsync(bvid, p);
    return a;
  }

  [HttpGet("{bvid}.xml")]
  [HttpGet("{bvid}/{p:int}.xml")]
  public async Task<OldBiliBiliDanMu?> GetXmlDanMuAsync(string bvid, int p = 1)
  {
    Response.ContentType = "text/xml";
    var a = await Bilibili.GetDanMuAsync(bvid, p);
    return (OldBiliBiliDanMu)a?.Elems;
  }
}