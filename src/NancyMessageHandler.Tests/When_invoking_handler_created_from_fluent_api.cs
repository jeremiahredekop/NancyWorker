using FluentAssertions;
using NUnit.Framework;
using NancyMessageHandler.Fluent;
using NancyMessageHandler.Implementations;
using NancyMessageHandler.Tests.Support;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class When_invoking_handler_created_from_fluent_api :SpecificationBase
    {
        public static bool Handled;
       
        private IMessage _message;
        private IMessageHandlerFacade _facade;

        private class MyModule : MessageModule
        {
            protected override void RegisterHandlers()
            {
                ForMessageType<PrototypeMessage>().Handle(m => Handled = true);
            }
        }

        protected override void Given()
        {
            _message = JsonTypedMessage.FromMessage(new PrototypeMessage());

            _facade = FluentHandlers.Init()
                                    .UsingTypeResolver()
                                    .WithAssemblyModuleTypes(GetType().Assembly, t => t == typeof (MyModule))
                                    .UsingReflectionModuleFactory()
                                    .Build();
        }

        protected override void When()
        {
            _facade.HandleMessage(_message);
        }

        [Then]
        public void The_message_should_have_been_handled()
        {
            Handled.Should().BeTrue();
        }
    }
}