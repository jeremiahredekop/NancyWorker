using System;

namespace NancyMessageHandler
{
    public interface ITypedMessageHandler
    {
        void Handle(ITypedMessage message);
        Type HandlerType { get; }
    }
}