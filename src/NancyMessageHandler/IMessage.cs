using System.Collections.Generic;

namespace NancyMessageHandler
{
    public interface IMessage
    {
        IDictionary<string, object> Headers { get; }
    }
}