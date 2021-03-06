using System.Text.Json;
using Danmu.Bili.Models.BiliBili;
using static Danmu.Bili.Utils.Globals.Url;

namespace Danmu.Bili.Utils.BiliBiliHelp;

public partial class BiliBiliHelp
{
    /// <summary>
    ///     获取Cid和时长
    /// </summary>
    /// <param name="aid">视频的aid</param>
    /// <param name="p">分p</param>
    /// <returns>cid</returns>
    public async Task<CidAndDuration?> GetCidAndDurationAsync(int aid, int p)
    {
        var pages = await GetBiliBiliPageAsync(aid);

        return pages == null ? null : GetCidAndDuration(pages, p);
    }

    /// <summary>
    ///     获取Cid和时长
    /// </summary>
    /// <param name="bvid"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public async Task<CidAndDuration?> GetCidAndDurationAsync(string bvid, int p)
    {
        var pages = await GetBiliBiliPageAsync(bvid);
        return pages == null ? null : GetCidAndDuration(pages, p);
    }


    /// <summary>
    ///     获取视频Cid和分P信息
    /// </summary>
    /// <param name="bvid"></param>
    /// <returns></returns>
    public async Task<BiliBiliPage?> GetBiliBiliPageAsync(string bvid)
    {
        //使用缓存
        return await _caching.GetAsync($"{nameof(GetBiliBiliPageAsync)}{bvid}",
            async () =>
            {
                var a = await GetBiliBiliDataRawAsync(BiliBiliPageUrl, new {bvid});
                if (!Equals(a, Stream.Null))
                    return await JsonSerializer.DeserializeAsync<BiliBiliPage>(a);
                return null;
            }, TimeSpan.FromHours(_setting.PageCacheTime));
    }

    /// <summary>
    ///     获取视频Cid和分P信息
    /// </summary>
    /// <param name="aid">视频的aid</param>
    /// <returns>Page数据</returns>
    public async Task<BiliBiliPage?> GetBiliBiliPageAsync(int aid)
    {
        return await _caching.GetAsync($"{nameof(GetBiliBiliPageAsync)}{aid}",
            async () =>
            {
                var a = await GetBiliBiliDataRawAsync(BiliBiliPageUrl, new {aid});
                if (!Equals(a, Stream.Null))
                    return await JsonSerializer.DeserializeAsync<BiliBiliPage>(a);
                return null;
            }, TimeSpan.FromHours(_setting.PageCacheTime));
    }

    /// <summary>
    ///     获取Cid
    /// </summary>
    /// <param name="pages">Page数据</param>
    /// <param name="p">分p</param>
    /// <returns>cid</returns>
    private CidAndDuration? GetCidAndDuration(BiliBiliPage pages, int p)
    {
        if (pages.Data != null)
        {
            var a = pages.Code == 0
                ? pages.Data.Where(e => e.Page == p).Select(s => new CidAndDuration
                {
                    Cid = s.Cid,
                    Duration = s.Duration
                }).FirstOrDefault()
                : null;

            return a;
        }

        return null;
    }
}