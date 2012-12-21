using System;

namespace NancyMessageHandler
{
    internal class MessageHandler<T> : IMessageHandler where T : class
    {
        private readonly Action<IMessage<T>> _innerHandler;

        public MessageHandler(Action<IMessage<T>> innerHandler, Type handlerType)
        {
            _innerHandler = innerHandler;
            HandlerType = handlerType;
        }

        public void Handle(IMessage message)
        {
            _innerHandler.Invoke(new MessageAdapter<T>(message));
        }

        public Type HandlerType { get; private set; }
    }
}