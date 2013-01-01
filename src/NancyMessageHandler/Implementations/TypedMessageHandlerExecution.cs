using System;

namespace NancyMessageHandler.Implementations
{
    internal class TypedMessageHandlerExecution<T> : ITypedMessageHandlerExtension<T> where T : class
    {
        private readonly MessageModule _module;
        private readonly TypedMessageHandlerFactory _context;

        public TypedMessageHandlerExecution(TypedMessageHandlerFactory context, MessageModule module)
        {
            _module = module;
            _context = context;
        }

        public void Handle(Action<ITypedMessage<T>> handler)
        {
            _context.RegisterHandler(typeof (T), new TypedMessageHandler<T>(handler, _module.GetType()));
        }
    }
}