using System.Linq;

namespace NancyMessageHandler.Implementations
{
    public class TypedMessageHandlerFacade : IMessageHandlerFacade
    {
        private readonly IHandlerTypeResolver _resolver;
        private readonly IModuleFactory _moduleFactory;

        public TypedMessageHandlerFacade(IHandlerTypeResolver resolver, IModuleFactory moduleFactory)
        {
            _resolver = resolver;
            _moduleFactory = moduleFactory;
        }

        public void HandleMessage(IMessage message)
        {
            var typedMessage = (ITypedMessage) message;
            var handlerType = _resolver.GetHandlersTypesForMessage(typedMessage).Single();
            var factory = TypedMessageHandlerFactory.ForMessage(typedMessage);
            var module = _moduleFactory.GetModule(handlerType);
            var handler = factory.GetHandlers(module).Single();
            handler.Handle(typedMessage);
        }
    }
}