using System;
using System.Collections.Generic;
using System.Linq;
using gcExtensions;

namespace NancyMessageHandler.Implementations
{
    public class HandlerTypeResolver : IHandlerTypeResolver
    {
        private HandlerTypeResolver(IEnumerable<MessageModule> handlers)
        {
            PathHandlers = new Dictionary<string, Type>();
            _typeMessageHandlers = new Dictionary<string, List<Type>>();

            if (handlers != null)
                handlers.ToList().ForEach(RegisterModule);
        }

        public void RegisterModule(MessageModule type)
        {
            type.ForRegistrations(this);
        }


        internal IDictionary<string, Type> PathHandlers { get; private set; }
        private readonly IDictionary<string, List<Type>> _typeMessageHandlers;

        internal void RegisterTypedHandler(Type messageType, Type moduleType)
        {
            var handlers = _typeMessageHandlers.GetOrCreateValue(messageType.AssemblyQualifiedName, () => new List<Type>());
            handlers.Add(moduleType);
        }

        public static HandlerTypeResolver Init(IEnumerable<MessageModule> handlers = null)
        {
            return new HandlerTypeResolver(handlers);
        }

        public IEnumerable<Type> GetHandlersTypesForMessage(ITypedMessage message)
        {
            List<Type> handlerTypes;
            _typeMessageHandlers.TryGetValue(message.AssemblyQualifiedTypeName, out handlerTypes);
            return handlerTypes;
        }


    }
}