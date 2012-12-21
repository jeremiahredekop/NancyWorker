using System;

namespace NancyMessageHandler
{
    public class ScopedMessageHandlerRegistration<T>
    {
        private readonly MessageRegistrationHost _host;
        private readonly HandlerModule _module;
        private readonly string _path;

        public ScopedMessageHandlerRegistration(MessageRegistrationHost host, HandlerModule module, string path)
        {
            _host = host;
            _module = module;
            _path = path;
        }

        public void Handle(Action<IMessage<T>> handler)
        {
            _host.PathHandlers.Add(_path,_module.GetType());
        }
    }
}