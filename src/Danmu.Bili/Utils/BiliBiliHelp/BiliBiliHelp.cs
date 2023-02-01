using Bilibili.Community.Service.Dm.V1;
using Danmu.Bili.Models.AppSettings;
using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Utils.Cache;
using Google.Protobuf;
using RestSharp;

namespace Danmu.Bili.Utils.BiliBiliHelp;

public partial class BiliBiliHelp
{
  // 接口
  private const string BaseUrl = "https://api.bilibili.com";
  private const string PageUrl = "/x/player/pagelist";
  private const string DanMuUrl = "/x/v2/dm/list/seg.so";

  private readonly RestClient _client;
  private readonly DanMuCache _danmuCache;
  private readonly PageCache _pageCache;
  private readonly BiliBiliSetting _setting;

  public BiliBiliHelp(AppSettings appSettings, RestClient client,
    PageCache pageCache, DanMuCache danMuCache)
  {
    _client = client;
    _setting = appSettings.BiliBiliSetting;
    _pageCache = pageCache;
    _danmuCache = danMuCache;
  }

  /// <summary>
  ///   获取B站弹幕 并返回通用弹幕格式
  /// </summary>
  /// <param name="id"></param>
  /// <param name="p"></param>
  /// <returns></returns>
  public async Task<DanmakuElem[]?> GetGenericDanMuAsync(string id = "", int p = 1)
  {
    var a = await GetDanMuAsync(id, p);

    if (a != null) return a.Elems.ToArray();

    return Array.Empty<DanmakuElem>();
  }


  /// <summary>
  ///   获取B站弹幕
  /// </summary>
  /// <param name="id"></param>
  /// <param name="p"></param>
  /// <returns></returns>
  public async Task<DmSegMobileReply?> GetDanMuAsync(string id = "", int p = 1)
  {
    var a = await GetDanMuStreamAsync(id, p);
    a.Position = 0;
    return Parse(a, DmSegMobileReply.Parser);
  }

  /// <summary>
  ///   获取B站弹幕数据流
  /// </summary>
  /// <param name="id"></param>
  /// <param name="p"></param>
  /// <returns></returns>
  public async Task<Stream> GetDanMuStreamAsync(string id = "", int p = 1)
  {
    var query = CheckBQuery(id, p);

    var cidAndDuration = await (query.Aid == 0
      ? GetCidAndDurationAsync(query.BVid, query.P)
      : GetCidAndDurationAsync(query.Aid, query.P));

    if (cidAndDuration != null && cidAndDuration.Cid != 0)
    {
      var a = await _danmuCache.GetOrSetAsync(cidAndDuration.Cid,
        async () =>
        {
          var dm = await GetDanMuNoCacheAsync(query, cidAndDuration);
          var ms = new MemoryStream();
          dm.WriteTo(ms);
          ms.Position = 0;
          return ms;
        },
        TimeSpan.FromHours(_setting.DanmuCacheTime));

      if (a != null) return a;
    }

    return Stream.Null;
  }

  private BQuery CheckBQuery(string id, int p)
  {
    var query = new BQuery();
    if (!string.IsNullOrWhiteSpace(id) && id.StartsWith("BV"))
    {
      query.BVid = id;
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

    return query;
  }


  /// <summary>
  ///   请求原始数据
  /// </summary>
  /// <param name="path"></param>
  /// <param name="queryParams"></param>
  /// <returns></returns>
  private async Task<Stream?> GetBiliBiliDataRawAsync(string path, Dictionary<string, string>? queryParams)
  {
    var request = new RestRequest(BaseUrl + path);
    if (queryParams != null)
      foreach (var item in queryParams)
        request.AddQueryParameter(item.Key, item.Value, false);
    return await _client.DownloadStreamAsync(request);
  }

  /// <summary>
  ///   反序列化数据
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="data"></param>
  /// <param name="parser"></param>
  /// <returns></returns>
  public static T Parse<T>(byte[] data, MessageParser<T> parser) where T : IMessage<T>
  {
    return parser.ParseFrom(data);
  }

  /// <summary>
  ///   反序列化数据
  /// </summary>
  /// <typeparam name="T"></typeparam>
  /// <param name="data"></param>
  /// <param name="parser"></param>
  /// <returns></returns>
  public static T Parse<T>(Stream data, MessageParser<T> parser) where T : IMessage<T>
  {
    return parser.ParseFrom(data);
  }

  /// <summary>
  ///   获取B站弹幕无缓存
  /// </summary>
  /// <param name="query"></param>
  /// <param name="cidAndDuration"></param>
  /// <returns></returns>
  private async Task<DmSegMobileReply?> GetDanMuNoCacheAsync(BQuery query, CidAndDuration cidAndDuration)
  {
    var d = cidAndDuration.Duration / 360 + 1;
    var getDanMuTaskList = new List<Task<Stream>>();

    for (var i = 0; i < d; i++)
    {
      var a = GetBiliBiliDataRawAsync(DanMuUrl, new Dictionary<string, string>
      {
        { "type", query.Type.ToString() },
        { "oid", cidAndDuration.Cid.ToString() },
        { "segment_index", (i + 1).ToString() }
      });

      getDanMuTaskList.Add(a!);
    }

    var danMuRawList = await Task.WhenAll(getDanMuTaskList);

    var danMuResponseList = danMuRawList.Where(w => !Equals(w, Stream.Null)).Select(s => s);

    var danMuSegList = danMuResponseList.Select(s => Parse(s, DmSegMobileReply.Parser));

    var dmSeg = new DmSegMobileReply
    {
      State = 0
    };

    foreach (var danMuSeg in danMuSegList) dmSeg.Elems.Add(danMuSeg.Elems);

    if (dmSeg.Elems.Count > 0) return dmSeg;

    return null;
  }
}