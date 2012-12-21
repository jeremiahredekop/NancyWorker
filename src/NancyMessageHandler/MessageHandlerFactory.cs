using System;
using System.Collections.Generic;
using gcExtensions;
namespace NancyMessageHandler
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {      
        public static IMessageHandlerFactory UsingModule(HandlerModule module)
        {
            return new MessageHandlerFactory(module);
        }

        private MessageHandlerFactory(HandlerModule module)
        {
            _typeMessageHandlers = new Dictionary<string, List<IMessageHandler>>();
            module.PrepHandlers(this);
        }

        internal void RegisterHandler(Type messageType, IMessageHandler handler)
        {
            var handlers = _typeMessageHandlers.GetOrCreateValue(messageType.AssemblyQualifiedName,
                                                                 () => new List<IMessageHandler>());
            handlers.Add(handler);
        }

        private readonly IDictionary<string, List<IMessageHandler>> _typeMessageHandlers;

        public IEnumerable<IMessageHandler> GetHandlersForMessage(IMessage message)
        {
            return _typeMessageHandlers[message.MessageBody.GetType().AssemblyQualifiedName];
        }

        public bool MessageHandlersExist(IMessage message)
        {
            return _typeMessageHandlers.ContainsKey(message.MessageBody.GetType().AssemblyQualifiedName);
        }
    }
}