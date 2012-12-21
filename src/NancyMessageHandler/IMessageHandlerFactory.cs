using System.Collections.Generic;

namespace NancyMessageHandler
{
    public interface IMessageHandlerFactory
    {
        IEnumerable<IMessageHandler> GetHandlersForMessage(IMessage message);
        bool MessageHandlersExist(IMessage message);
    }

}