using System;

namespace NancyMessageHandler
{
    public interface IMessageHandlerExtension<out T> where T : class
    {
        void Handle(Action<IMessage<T>> handler);
    }
}