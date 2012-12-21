using System.Collections.Generic;

namespace NancyMessageHandler
{
    public interface IMessageHandlerFactory
    {
        IEnumerable<IMessageHandler> GetHandlers(MessageModule message);
    }
}