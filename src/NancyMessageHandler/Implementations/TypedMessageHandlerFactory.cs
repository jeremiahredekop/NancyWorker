using System;
using System.Collections.Generic;
using gcExtensions;

namespace NancyMessageHandler.Implementations
{
    public class TypedMessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly ITypedMessage _message;

        public static IMessageHandlerFactory ForMessage(ITypedMessage message)
        {
            return new TypedMessageHandlerFactory(message);
        }

        private TypedMessageHandlerFactory(ITypedMessage message)
        {
            _message = message;
        }

        internal void RegisterHandler(Type messageType, ITypedMessageHandler handler)
        {
            var handlers = _typeMessageHandlers.GetOrCreateValue(messageType.AssemblyQualifiedName,
                                                                 () => new List<ITypedMessageHandler>());
            handlers.Add(handler);
        }

        private IDictionary<string, List<ITypedMessageHandler>> _typeMessageHandlers;

        public IEnumerable<ITypedMessageHandler> GetHandlers(MessageModule module)
        {
            _typeMessageHandlers = new Dictionary<string, List<ITypedMessageHandler>>();
            module.PrepHandlers(this);
            return _typeMessageHandlers[_message.AssemblyQualifiedTypeName];
        }

        public bool MessageHandlersExist(ITypedMessage message)
        {
            return _typeMessageHandlers.ContainsKey(message.AssemblyQualifiedTypeName);
        }
    }
}