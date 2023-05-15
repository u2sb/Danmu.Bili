using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Models.Settings;
using LiteDB.Async;

namespace Danmu.Bili.Utils.Caching;

public class CachingContext
{
  /// <summary>
  ///   BiliBili Page 缓存库
  /// </summary>
  public ILiteCollectionAsync<BiliBiliPagesCaching> BiliBiliPagesCaching;

  /// <summary>
  ///   BiliBili 弹幕缓存库
  /// </summary>
  public ILiteStorageAsync<int> BiliDanMuCache;

  public CachingContext(AppSettings appSettings)
  {
    Database = new LiteDatabaseAsync(Path.Combine(appSettings.DataBase.Directory, appSettings.DataBase.CachingDb));

    // BiliBili Page 缓存库
    BiliBiliPagesCaching = Database.GetCollection<BiliBiliPagesCaching>("BiliPages");
    BiliBiliPagesCaching.EnsureIndexAsync(x => x.Id);

    // 弹幕缓存库
    BiliDanMuCache = Database.GetStorage<int>("BiliDanMu", "_biliDanMuChunks");
  }

  public LiteDatabaseAsync Database { get; }
}