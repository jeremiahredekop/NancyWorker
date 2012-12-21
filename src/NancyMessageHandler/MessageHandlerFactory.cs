using System;
using System.Collections.Generic;
using gcExtensions;
namespace NancyMessageHandler
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly IMessage _message;

        public static IMessageHandlerFactory ForMessage(IMessage message)
        {
            return new MessageHandlerFactory(message);
        }

        private MessageHandlerFactory(IMessage message)
        {
            _message = message;
        }

        internal void RegisterHandler(Type messageType, IMessageHandler handler)
        {
            var handlers = _typeMessageHandlers.GetOrCreateValue(messageType.AssemblyQualifiedName,
                                                                 () => new List<IMessageHandler>());
            handlers.Add(handler);
        }

        private IDictionary<string, List<IMessageHandler>> _typeMessageHandlers;

        public IEnumerable<IMessageHandler> GetHandlers(MessageModule module)
        {
            _typeMessageHandlers = new Dictionary<string, List<IMessageHandler>>();
            module.PrepHandlers(this);
            return _typeMessageHandlers[_message.MessageBody.GetType().AssemblyQualifiedName];
        }

        public bool MessageHandlersExist(IMessage message)
        {
            return _typeMessageHandlers.ContainsKey(message.MessageBody.GetType().AssemblyQualifiedName);
        }
    }
}