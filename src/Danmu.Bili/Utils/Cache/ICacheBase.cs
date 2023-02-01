namespace Danmu.Bili.Utils.Cache;

public interface ICacheBase<T, in TU> where T : class
{
  public Task<T?> GetOrSetAsync(TU key, Func<Task<T?>> factory, TimeSpan expiration);
}