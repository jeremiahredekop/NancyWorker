using System;

namespace NancyMessageHandler
{
    public class ScopedMessageHandlerRegistration<T>
    {
        private readonly MessageRegistrationHost _host;
        private readonly MessageModule _module;
        private readonly string _path;

        public ScopedMessageHandlerRegistration(MessageRegistrationHost host, MessageModule module, string path)
        {
            _host = host;
            _module = module;
            _path = path;
        }

        public void Handle(Action<ITypedMessage<T>> handler)
        {
            _host.PathHandlers.Add(_path,_module.GetType());
        }
    }
}