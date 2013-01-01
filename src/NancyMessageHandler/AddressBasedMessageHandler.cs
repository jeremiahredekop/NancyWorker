namespace NancyMessageHandler.Implementations
{

    //TODO: This class is way wrong
    public class AddressBasedMessageHandler
    {
        private readonly IHandlerTypeResolver _host;
        private readonly MessageModule _module;

        public AddressBasedMessageHandler(IHandlerTypeResolver host, MessageModule module)
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