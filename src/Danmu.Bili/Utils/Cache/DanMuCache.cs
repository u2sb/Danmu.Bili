using LiteDB.Async;

namespace Danmu.Bili.Utils.Cache;

public class DanMuCache : ICacheBase<Stream, int>
{
  private readonly ILiteStorageAsync<int> _danmuCache;

  public DanMuCache(DanMuCacheDbContext context)
  {
    _danmuCache = context.DanMuCache;
  }

  public async Task<Stream?> GetOrSetAsync(int key, Func<Task<Stream?>> factory,
    TimeSpan expiration)
  {
    var a = await _danmuCache.FindByIdAsync(key);
    if (a != null && a.UploadDate.Add(expiration) > DateTime.UtcNow)
    {
      var b = await _danmuCache.FindByIdAsync(key);

      if (b != null)
      {
        var ms = new MemoryStream();
        b.CopyTo(ms);
        return ms;
      }
    }

    var f = await factory.Invoke();
    if (f != null)
    {
      f.Position = 0;
      await _danmuCache.UploadAsync(key, key.ToString(), f);
    }

    return f;
  }
}