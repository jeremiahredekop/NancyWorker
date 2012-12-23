namespace NancyMessageHandler
{
    public class AddressBasedMessageHandler
    {
        private readonly MessageRegistrationHost _host;
        private readonly MessageModule _module;

        public AddressBasedMessageHandler(MessageRegistrationHost host, MessageModule module)
        {
            _host = host;
            _module = module;
        }

        public ITypedMessageHandlerExtension<T> ForMessageType<T>() where T : class
        {
            return new TypedMessageHandlerRegistration<T>(_host,_module);
        }
    }
}