using Danmu.Bili.Utils.BiliBiliHelp;

using Microsoft.AspNetCore.Mvc;

namespace Danmu.Bili.Controllers.Api.Base
{
    [FormatFilter]
    [ApiController]
    public class BiliBiliBaseController : ControllerBase
    {
        private protected readonly BiliBiliHelp Bilibili;

        public BiliBiliBaseController(BiliBiliHelp bilibili)
        {
            Bilibili = bilibili;
        }
    }
}
