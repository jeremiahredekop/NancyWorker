using System;

namespace NancyMessageHandler
{
    public interface ITypedMessageHandlerExtension<out T> where T : class
    {
        void Handle(Action<ITypedMessage<T>> handler);
    }
}