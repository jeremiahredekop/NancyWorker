using System.Collections.Generic;

namespace NancyMessageHandler
{
    public interface IMessageHandlerFactory
    {
        IEnumerable<ITypedMessageHandler> GetHandlers(MessageModule message);
    }
}