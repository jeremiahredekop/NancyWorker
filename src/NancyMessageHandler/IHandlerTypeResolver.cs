using System;
using System.Collections.Generic;
using NancyMessageHandler.Implementations;

namespace NancyMessageHandler
{
    public interface IHandlerTypeResolver
    {
        IEnumerable<Type> GetHandlersTypesForMessage(ITypedMessage message);
        void RegisterModule(MessageModule type);
    }
}