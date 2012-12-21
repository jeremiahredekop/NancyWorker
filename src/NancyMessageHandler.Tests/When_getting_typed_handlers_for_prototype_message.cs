using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NancyMessageHandler.Tests.Support;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class When_getting_handlers_with_no_address_for_prototype_message : SpecificationBase
    {
        public class PrototypeHandler : HandlerModule
        {
            protected override void RegisterHandlers()
            {
                ForMessageType<PrototypeMessage>().Handle(x => { });
            }
        }

        private Type _handler;

        protected override void Given()
        {
            var registrations = new List<HandlerModule> {new PrototypeHandler()};

            var host = MessageRegistrationHost.Init(registrations);

            var message = new Support.SimpleMessage(new PrototypeMessage());
            var handlerTypes = host.GetGenericHandlersTypesForMessage(message);
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
            _handler.Should().Be<PrototypeHandler>();
        }
    }
}