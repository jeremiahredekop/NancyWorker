using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NancyMessageHandler.Tests.Support;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class When_invoking_message_handler_with_no_address : SpecificationBase
    {
        public class PrototypeModule : MessageModule
        {
            public int Counter;

            protected override void RegisterHandlers()
            {
                ForMessageType<PrototypeMessage>().Handle(x => { Counter++; });
            }
        }

        private IMessageHandler _handler;
        private PrototypeModule _module;
        private IMessageHandlerFactory _context;
        private Support.SimpleMessage _message;

        protected override void Given()
        {
            _message = new Support.SimpleMessage(new PrototypeMessage());
            _module = new PrototypeModule();
            _context = MessageHandlerFactory.UsingModule(_module);
            _handler = _context.GetHandlersForMessage(_message).Single();
        }

        protected override void When()
        {
            
            _handler.Handle(_message);
        }

        [Then]
        public void the_factory_should_return_a_handler_is_available()
        {
            _context.MessageHandlersExist(_message).Should().BeTrue();
        }

        [Then]
        public void handler_should_support_message()
        {
            _handler.HandlerType.Should().Be<PrototypeModule>();
        }

        [Then]
        public void invoking_the_handler_should_behave_as_expected()
        {
            
            _module.Counter.Should().Be(1);
        }
    }
}