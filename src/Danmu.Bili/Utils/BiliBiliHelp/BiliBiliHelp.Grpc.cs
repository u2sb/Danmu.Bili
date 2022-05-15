using Google.Protobuf;

namespace Danmu.Bili.Utils.BiliBiliHelp;

public partial class BiliBiliHelp
{
    /// <summary>
    ///     格式化数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="response"></param>
    /// <param name="parser"></param>
    /// <returns></returns>
    public async Task<T> ParseAsync<T>(HttpResponseMessage response, MessageParser<T> parser)
        where T : IMessage<T>
    {
        var bytes = await response.Content.ReadAsByteArrayAsync();
        return parser.ParseFrom(bytes);
    }

    /// <summary>
    ///     格式化数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="parser"></param>
    /// <returns></returns>
    public T Parse<T>(byte[] data, MessageParser<T> parser)
        where T : IMessage<T>
    {
        return parser.ParseFrom(data);
    }

    /// <summary>
    ///     格式化数据
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="parser"></param>
    /// <returns></returns>
    public T Parse<T>(Stream data, MessageParser<T> parser)
        where T : IMessage<T>
    {
        return parser.ParseFrom(data);
    }
}