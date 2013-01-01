using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NancyMessageHandler.Implementations;
using NancyMessageHandler.Tests.Support;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class When_getting_handlers_with_no_path_for_prototype_message : SpecificationBase
    {
        public class PrototypeModule : MessageModule
        {
            protected override void RegisterHandlers()
            {
                ForMessageType<PrototypeMessage>().Handle(x => { });
            }
        }

        private Type _handler;
        private ITypedMessage _message;
        private HandlerTypeResolver _host;

        protected override void Given()
        {
            var registrations = new List<MessageModule> {new PrototypeModule()};
            _host = HandlerTypeResolver.Init(registrations);
            _message = JsonTypedMessage.FromMessage(new PrototypeMessage());
        }

        protected override void When()
        {
            IEnumerable<Type> handlerTypes = _host.GetHandlersTypesForMessage(_message);
            _handler = handlerTypes.SingleOrDefault();
        }

        [Then]
        public void there_should_be_a_single_handler()
        {
            (_handler == null).Should().Be(false);
        }

        [Then]
        public void the_handler_type_should_be_expected()
        {
            _handler.Should().Be<PrototypeModule>();
        }
    }
}