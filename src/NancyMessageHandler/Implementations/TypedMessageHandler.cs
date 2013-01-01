using System;

namespace NancyMessageHandler.Implementations
{
    internal class TypedMessageHandler<T> : ITypedMessageHandler where T : class
    {
        private readonly Action<ITypedMessage<T>> _innerHandler;

        public TypedMessageHandler(Action<ITypedMessage<T>> innerHandler, Type handlerType)
        {
            _innerHandler = innerHandler;
            HandlerType = handlerType;
        }

        public void Handle(ITypedMessage message)
        {
            _innerHandler.Invoke(new MessageAdapter<T>(message));
        }

        public Type HandlerType { get; private set; }
    }
}