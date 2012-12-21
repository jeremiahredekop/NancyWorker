using System;
using System.Collections.Generic;
using System.Linq;
using gcExtensions;

namespace NancyMessageHandler
{
    public class MessageRegistrationHost
    {
        private readonly IEnumerable<MessageModule> _handlers;

        private MessageRegistrationHost(IEnumerable<MessageModule> handlers )
        {
            _handlers = handlers;
            PathHandlers = new Dictionary<string, Type>();
            _typeMessageHandlers = new Dictionary<string, List<Type>>();

            _handlers.ToList().ForEach(h=> h.ForRegistrations(this));
        }

        internal IDictionary<string, Type> PathHandlers { get; private set; }
        private readonly IDictionary<string, List<Type>> _typeMessageHandlers;

        internal void RegisterTypedHandler(Type messageType, Type moduleType)
        {
            var handlers = _typeMessageHandlers.GetOrCreateValue(messageType.AssemblyQualifiedName, () => new List<Type>());
            handlers.Add(moduleType);
        }

        public static MessageRegistrationHost Init(IEnumerable<MessageModule> handlers)
        {
            return new MessageRegistrationHost(handlers);
        }

        public IEnumerable<Type> GetGenericHandlersTypesForMessage(ITypedMessage message)
        {
            List<Type> handlerTypes;
            _typeMessageHandlers.TryGetValue(message.AssemblyQualifiedTypeName, out handlerTypes);
            return handlerTypes;
        }
    }
}