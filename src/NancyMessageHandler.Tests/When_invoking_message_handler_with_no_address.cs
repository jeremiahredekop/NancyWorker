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

        private ITypedMessageHandler _handler;
        private PrototypeModule _module;
        private IMessageHandlerFactory _factory;
        private ITypedMessage _message;

        protected override void Given()
        {
            _message = JsonTypedMessage.FromMessage(new PrototypeMessage());
            _module = new PrototypeModule();
            _factory = TypedMessageHandlerFactory.ForMessage(_message);
            _handler = _factory.GetHandlers(_module).Single();
        }

        protected override void When()
        {
            _handler.Handle(_message);
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