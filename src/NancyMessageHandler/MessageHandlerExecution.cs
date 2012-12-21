using System;

namespace NancyMessageHandler
{
    internal class MessageHandlerExecution<T> : IMessageHandlerExtension<T> where T : class
    {
        private readonly MessageModule _module;
        private readonly MessageHandlerFactory _context;

        public MessageHandlerExecution(MessageHandlerFactory context, MessageModule module)
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