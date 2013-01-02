Nancy Workers
---------------

This .net library is inspired by the [Nancy FX project](http://nancyfx.org/). The purpose is to have a little framework that workers can use to handle messages in a matter that is decoupled from any particular queueing infrastructure.



**Goals:**  

  - Simple Modules to contain handlers
  - Handlers declared in Nancy style, as opposed to IHandle < TMessage >
  - Minimum fluent api to set up 

**Decisions:**

  - Messages are deserialized by type
  - Message type identified by string value
  - Modules do not have address
  - Message can include Module name as a filter

**State:**

This library is currently an experiment.  I am exploring to find the sweet spot I'll be using in a project or two.

**License:**

Open source - BSD.

**The Code:**

Here's an example of what I'm aiming for.

'''csharp

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
'''