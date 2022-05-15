using EasyCaching.Core;
using static Danmu.Bili.Utils.Globals.VariableDictionary;

namespace Danmu.Bili.Utils.Cache;

public class CacheLiteDb
{
    private readonly IEasyCachingProvider _caching;

    public CacheLiteDb(IEasyCachingProviderFactory cacheFactory)
    {
        _caching = cacheFactory.GetCachingProvider(BiliBiliDanmuCacheLiteDb);
    }

    public async Task<T?> GetAsync<T>(string key, Func<Task<T>> factory, TimeSpan expiration)
    {
        T? t = default;
        var a = await _caching.GetAsync<T>(key);
        if (!a.HasValue || a.IsNull)
        {
            t = await factory.Invoke();
            if (t != null) await _caching.SetAsync(key, t, expiration);
        }
        else
        {
            t = a.Value;
        }
        return t;
    }
}