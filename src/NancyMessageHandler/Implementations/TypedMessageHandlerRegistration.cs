using System;

namespace NancyMessageHandler.Implementations
{
    internal class TypedMessageHandlerRegistration<T> : ITypedMessageHandlerExtension<T> where T: class
    {
        private readonly HandlerTypeResolver _host;
        private readonly MessageModule _module;

        public TypedMessageHandlerRegistration(IHandlerTypeResolver host, MessageModule module)
        {
            _host = (HandlerTypeResolver) host;
            _module = module;
        }

        public void Handle(Action<ITypedMessage<T>> handler)
        {
            _host.RegisterTypedHandler(typeof(T),_module.GetType());
        }
    }
}