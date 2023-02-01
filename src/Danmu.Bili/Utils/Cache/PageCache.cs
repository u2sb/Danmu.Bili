using Danmu.Bili.Models.BiliBili;
using Danmu.Bili.Models.BiliBili.Cache;
using LiteDB.Async;

namespace Danmu.Bili.Utils.Cache;

public class PageCache : ICacheBase<BPage, string>
{
  private readonly ILiteCollectionAsync<PageCacheTable> _pageCache;

  public PageCache(DanMuCacheDbContext context)
  {
    _pageCache = context.PageCache;
  }

  public async Task<BPage?> GetOrSetAsync(string key, Func<Task<BPage?>> factory, TimeSpan expiration)
  {
    var a = await _pageCache.Query().Where(x => x.Id == key).FirstOrDefaultAsync();

    if (a is { Page: { } } && a.DateTime.Add(expiration) > DateTime.UtcNow) return a.Page;

    var b = await factory.Invoke();
    if (b is { Data.Length: > 0 })
      await _pageCache.UpsertAsync(new PageCacheTable
      {
        Id = key,
        Page = b,
        DateTime = DateTime.UtcNow
      });
    else
      b = a?.Page;

    return b;
  }
}