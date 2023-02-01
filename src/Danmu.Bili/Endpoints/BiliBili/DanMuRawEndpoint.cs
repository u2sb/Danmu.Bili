using Danmu.Bili.Models.BiliBili.Endpoint;
using Danmu.Bili.Utils.BiliBiliHelp;
using FastEndpoints;

namespace Danmu.Bili.Endpoints.BiliBili;

public class DanMuRawEndpoint : Endpoint<DanMuRequest, Stream>
{
  private readonly BiliBiliHelp _bilibili;

  public DanMuRawEndpoint(BiliBiliHelp bilibili)
  {
    _bilibili = bilibili;
  }

  public override void Configure()
  {
    Get("/bilibili/raw/{Id}/{P:int?}");
    AllowAnonymous();
  }

  public override async Task HandleAsync(DanMuRequest req, CancellationToken ct)
  {
    var a = await _bilibili.GetDanMuStreamAsync(req.Id, req.P);
    a.Position = 0;
    await SendStreamAsync(a, cancellation: ct);
  }
}