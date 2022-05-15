using Flurl;
using Flurl.Http;

namespace Danmu.Bili.Utils.BiliBiliHelp;

public partial class BiliBiliHelp
{
    /// <summary>
    ///     发起查询请求
    /// </summary>
    /// <param name="path"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    private async Task<Stream> GetBiliBiliDataRawAsync(string path, object queryParams)
    {
        return await _flurlClient.Request(path).SetQueryParams(queryParams).GetStreamAsync();
    }
}