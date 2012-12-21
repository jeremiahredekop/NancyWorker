using System;

namespace NancyMessageHandler
{
    public abstract class MessageModule
    {
        private readonly string _rootuUl;
        private MessageRegistrationHost _host;

        protected MessageModule()
        {   
        }

        protected MessageModule(string rootuUl)
        {
            _rootuUl = rootuUl;
        }

        internal void ForRegistrations(MessageRegistrationHost host)
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

        protected IMessageHandlerExtension<T> ForMessageType<T>() where T : class
        {
            switch (_handlerExecutionMode)
            {
                    case HandlerExecutionMode.Registration:
                        return new MessageHandlerRegistration<T>(_host, this);
                    case HandlerExecutionMode.Execution:
                        return new MessageHandlerExecution<T>(_messageHandlerFactory, this);
                    default:
                        throw new NotImplementedException();
            }           
        }

        protected AddressBasedMessageHandler AtAddress(string yo)
        {
            return new AddressBasedMessageHandler(_host,this);
        }

        private MessageHandlerFactory _messageHandlerFactory;

        public void PrepHandlers(MessageHandlerFactory messageHandlerFactory)
        {
            _handlerExecutionMode = HandlerExecutionMode.Execution;
            _messageHandlerFactory = messageHandlerFactory;
            RegisterHandlers();
        }
    }
}