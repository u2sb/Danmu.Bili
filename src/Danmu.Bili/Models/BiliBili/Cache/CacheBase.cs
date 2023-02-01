namespace Danmu.Bili.Models.BiliBili.Cache
{
  public class CacheBase
  {
    public virtual string Id { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
  }
}
