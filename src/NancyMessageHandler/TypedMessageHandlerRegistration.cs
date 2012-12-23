using System;
using System.Collections.Generic;
using gcExtensions;

namespace NancyMessageHandler
{
    internal class TypedMessageHandlerRegistration<T> : ITypedMessageHandlerExtension<T> where T: class
    {
        private readonly MessageRegistrationHost _host;
        private readonly MessageModule _module;

        public TypedMessageHandlerRegistration(MessageRegistrationHost host, MessageModule module)
        {
            _host = host;
            _module = module;
        }

        public void Handle(Action<ITypedMessage<T>> handler)
        {
            _host.RegisterTypedHandler(typeof(T),_module.GetType());
        }
    }
}