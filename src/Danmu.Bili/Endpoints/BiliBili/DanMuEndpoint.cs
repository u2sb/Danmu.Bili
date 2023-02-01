using System.Xml.Serialization;
using Danmu.Bili.Models.BiliBili.Endpoint;
using Danmu.Bili.Models.Danmu.BiliBili;
using Danmu.Bili.Utils.BiliBiliHelp;
using FastEndpoints;

namespace Danmu.Bili.Endpoints.BiliBili;

public class DanMuEndpoint : Endpoint<DanMuRequest>
{
  private readonly BiliBiliHelp _bilibili;

  public DanMuEndpoint(BiliBiliHelp bilibili)
  {
    _bilibili = bilibili;
  }

  public override void Configure()
  {
    Get("/bilibili/danmu/{Id}", "/bilibili/danmu/{Id}/{P:int}", "/bilibili/danmu/{Id}.{Ext}", "/bilibili/danmu/{Id}/{P:int}.{Ext}");

    AllowAnonymous();
  }

  public override async Task HandleAsync(DanMuRequest req, CancellationToken ct)
  {
    if (req.Ext.ToLower() == "json")
    {
      var a = await _bilibili.GetDanMuAsync(req.Id, req.P);
      if (a != null) await SendAsync(a, cancellation: ct);
    }
    else if (req.Ext.ToLower() == "xml")
    {
      var a = await _bilibili.GetDanMuAsync(req.Id, req.P);
      if (a != null)
      {
        var b = (OldBiliBiliDanmu)a.Elems;
        var s = new XmlSerializer(typeof(OldBiliBiliDanmu));
        var ms = new MemoryStream();
        s.Serialize(ms, b);
        ms.Position = 0;
        await SendStreamAsync(ms, contentType: "application/xml", cancellation: ct);
      }
    }
    else
    {
      await SendEmptyJsonObject(ct);
    }
  }
}