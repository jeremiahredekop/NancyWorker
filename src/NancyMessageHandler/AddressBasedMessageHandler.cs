namespace NancyMessageHandler
{
    public class AddressBasedMessageHandler
    {
        private readonly MessageRegistrationHost _host;
        private readonly HandlerModule _module;

        public AddressBasedMessageHandler(MessageRegistrationHost host, HandlerModule module)
        {
            _host = host;
            _module = module;
        }

        public IMessageHandlerExtension<T> ForMessageType<T>() where T : class
        {
            return new MessageHandlerRegistration<T>(_host,_module);
        }
    }
}