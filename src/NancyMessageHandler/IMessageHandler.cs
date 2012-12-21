using System;

namespace NancyMessageHandler
{
    public interface IMessageHandler
    {
        void Handle(IMessage message);
        Type HandlerType { get; }
    }
}