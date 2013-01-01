using System.Collections.Generic;
using NancyMessageHandler.Implementations;

namespace NancyMessageHandler
{
    public interface IMessageHandlerFactory
    {
        IEnumerable<ITypedMessageHandler> GetHandlers(MessageModule message);
    }
}