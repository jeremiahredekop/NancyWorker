using System;
using System.Collections.Generic;
using gcExtensions;

namespace NancyMessageHandler
{
    internal class MessageHandlerRegistration<T> : IMessageHandlerExtension<T> where T: class
    {
        private readonly MessageRegistrationHost _host;
        private readonly HandlerModule _module;

        public MessageHandlerRegistration(MessageRegistrationHost host, HandlerModule module)
        {
            _host = host;
            _module = module;
        }

        public void Handle(Action<IMessage<T>> handler)
        {
            _host.RegisterTypedHandler(typeof(T),_module.GetType());
        }
    }
}