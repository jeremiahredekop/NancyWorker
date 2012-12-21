using System;

namespace NancyMessageHandler
{
    internal class MessageHandlerExecution<T> : IMessageHandlerExtension<T> where T : class
    {
        private readonly HandlerModule _module;
        private readonly MessageHandlerFactory _context;

        public MessageHandlerExecution(MessageHandlerFactory context, HandlerModule module)
        {
            _module = module;
            _context = context;
        }

        public void Handle(Action<IMessage<T>> handler)
        {
            _context.RegisterHandler(typeof (T), new MessageHandler<T>(handler, _module.GetType()));
        }
    }
}