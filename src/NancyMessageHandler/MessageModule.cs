using System;

namespace NancyMessageHandler.Implementations
{
    public abstract class MessageModule
    {
        private readonly string _rootuUl;
        private IHandlerTypeResolver _host;

        protected MessageModule()
        {   
        }

        protected MessageModule(string rootuUl)
        {
            _rootuUl = rootuUl;
        }

        internal void ForRegistrations(IHandlerTypeResolver host)
        {
            _handlerExecutionMode = HandlerExecutionMode.Registration;
            _host = host;
            RegisterHandlers();
        }


        protected abstract void RegisterHandlers();

        private enum HandlerExecutionMode
        {
            Registration = 1,
            Execution
        };

        private HandlerExecutionMode _handlerExecutionMode;

        protected ITypedMessageHandlerExtension<T> ForMessageType<T>() where T : class
        {
            switch (_handlerExecutionMode)
            {
                    case HandlerExecutionMode.Registration:
                        return new TypedMessageHandlerRegistration<T>((HandlerTypeResolver) _host, this);
                    case HandlerExecutionMode.Execution:
                        return new TypedMessageHandlerExecution<T>(_typedMessageHandlerFactory, this);
                    default:
                        throw new NotImplementedException();
            }           
        }

        protected AddressBasedMessageHandler AtAddress(string yo)
        {
            return new AddressBasedMessageHandler((HandlerTypeResolver) _host,this);
        }

        private TypedMessageHandlerFactory _typedMessageHandlerFactory;

        internal void PrepHandlers(TypedMessageHandlerFactory typedMessageHandlerFactory)
        {
            _handlerExecutionMode = HandlerExecutionMode.Execution;
            _typedMessageHandlerFactory = typedMessageHandlerFactory;
            RegisterHandlers();
        }
    }
}
