using Danmu.Bili.Utils.BiliBili;
using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.Base;

[FormatFilter]
[ApiController]
public class BiliBiliDanMuBaseController : ControllerBase
{
  private protected readonly BiliBiliHelp Bilibili;

  public BiliBiliDanMuBaseController(BiliBiliHelp bilibili)
  {
    Bilibili = bilibili;
  }
}