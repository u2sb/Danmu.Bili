using Danmu.Bili.Models.AppSettings;
using Danmu.Bili.Models.BiliBili.Cache;
using LiteDB.Async;

namespace Danmu.Bili.Utils.Cache;

public class DanMuCacheDbContext
{
  public ILiteStorageAsync<int> DanMuCache;
  public ILiteCollectionAsync<PageCacheTable> PageCache;

  public DanMuCacheDbContext(AppSettings appSettings)
  {
    Database =
      new LiteDatabaseAsync(Path.Combine(appSettings.DataBase.Directory, appSettings.DataBase.DanmuCachingDb));

    PageCache = Database.GetCollection<PageCacheTable>("page");
    DanMuCache = Database.GetStorage<int>("danmu");

    var mapper = Database.UnderlyingDatabase.Mapper;

    PageCache.EnsureIndexAsync(x => x.Id);
  }

  public LiteDatabaseAsync Database { get; }
}