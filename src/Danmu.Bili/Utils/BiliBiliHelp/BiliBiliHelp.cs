using Bilibili.Community.Service.Dm.V1;
using Danmu.Bili.Models.AppSettings;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Utils.Cache;
using Flurl.Http;
using Flurl.Http.Configuration;
using static Danmu.Bili.Utils.Globals.Url;

namespace Danmu.Bili.Utils.BiliBiliHelp;

public partial class BiliBiliHelp
{
    private readonly CacheLiteDb _caching;
    private readonly IFlurlClient _flurlClient;
    private readonly BiliBiliSetting _setting;

    public BiliBiliHelp(AppSettings appSettings, IFlurlClientFactory flurlClientFac,
        CacheLiteDb cache)
    {
        _flurlClient = flurlClientFac.Get(BiliBiliApiBaseUrl);
        _caching = cache;
        _setting = appSettings.BiliBiliSetting;
    }

    /// <summary>
    ///     获取B站弹幕
    /// </summary>
    /// <param name="query"></param>
    /// <param name="id"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public async Task<DmSegMobileReply?> GetDanmuAsync(BiliBiliQuery query, string? id, int p)
    {
        if (!string.IsNullOrWhiteSpace(id) && id.StartsWith("BV"))
        {
            query.Bvid = id;
            query.P = p;
        }
        else if (!string.IsNullOrWhiteSpace(id) && id.StartsWith("av"))
        {
            if (int.TryParse(id.Remove(0, 2), out var aid))
            {
                query.Aid = aid;
                query.P = p;
            }
        }

        return await GetDanmuAsync(query);
    }

    /// <summary>
    ///     获取B站弹幕
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<DmSegMobileReply?> GetDanmuAsync(BiliBiliQuery query)
    {
        var cidAndDuration = await (query.Aid == 0
            ? GetCidAndDurationAsync(query.Bvid, query.P)
            : GetCidAndDurationAsync(query.Aid, query.P));


        if (cidAndDuration != null && cidAndDuration.Cid != 0)
            return await _caching.GetAsync($"{nameof(GetDanmuAsync)}{cidAndDuration.Cid}",
                async () =>
                {
                    var d = cidAndDuration.Duration / 360 + 1;
                    var getDanmuTaskList = new List<Task<Stream>>();

                    for (var i = 0; i < d; i++)
                    {
                        var a = GetBiliBiliDataRawAsync(BiliBiliDanmuUrl, new
                        {
                            type = query.Type,
                            oid = cidAndDuration.Cid,
                            segment_index = i + 1
                        });
                        getDanmuTaskList.Add(a);
                    }

                    var danmuRawList = await Task.WhenAll(getDanmuTaskList);

                    var danmuResponseList = danmuRawList.Where(w => !Equals(w, Stream.Null)).Select(s => s);


                    var danmuSegList = danmuResponseList.Select(s => Parse(s, DmSegMobileReply.Parser));

                    var dmSeg = new DmSegMobileReply
                    {
                        State = 0
                    };

                    foreach (var danmuSeg in danmuSegList) dmSeg.Elems.Add(danmuSeg.Elems);

                    if (dmSeg.Elems.Count > 0) return dmSeg;

                    return null;
                },
                TimeSpan.FromHours(_setting.DanmuCacheTime));

        return null;
    }
}