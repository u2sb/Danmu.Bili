using System.ComponentModel;
using System.Xml.Serialization;
using Bilibili.Community.Service.Dm.V1;
using Google.Protobuf.Collections;

namespace Danmu.Bili.Models.Danmu.BiliBili;

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot("i", Namespace = "", IsNullable = false)]
public class OldBiliBiliDanmu
{
    [XmlElement("d")] public D[]? D { get; set; }

    public static explicit operator OldBiliBiliDanmu(RepeatedField<DanmakuElem>? data)
    {
        var d = data?.Select(s => new D
        {
            P =
                $"{s.Progress / 1000f},{s.Mode},{s.Fontsize},{s.Color},{s.Ctime},{s.Pool},{s.MidHash},{s.Id}, {s.Weight}",
            Value = s.Content
        }).ToArray();
        return new OldBiliBiliDanmu {D = d};
    }
}

[Serializable]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class D
{
    [XmlAttribute("p")] public string? P { get; set; }

    [XmlText] public string? Value { get; set; }
}