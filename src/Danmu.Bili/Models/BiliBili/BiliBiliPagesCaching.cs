using LiteDB;

namespace Danmu.Bili.Models.BiliBili;

public class BiliBiliPagesCaching
{
  public ObjectId _id { get; set; } = ObjectId.NewObjectId();
  public string? BvId { get; set; }

  public BiliBiliPages? Pages { get; set; }

  /// <summary>
  ///   缓存更新时间
  /// </summary>
  public DateTime DateTime { get; set; } = DateTime.UtcNow;
}