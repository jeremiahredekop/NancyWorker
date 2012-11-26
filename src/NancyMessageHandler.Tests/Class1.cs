using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class Class1 
    {
    }


    public class StaticPrototype
    { }

    public class PrototypeHandler : JsonHandlerModule
    {
        public PrototypeHandler()
            : base("/products")
        {
        }

        protected override void RegisterHandlers()
        {
            Handle["/"] = DoSomething;
            Handle["/Yo"] = a => a.DeserializeAs<StaticPrototype>(DoSomethingElse);
            Handle.AddStrongHandler<StaticPrototype>("/Yo", SomethingFurther);
            Handle["/IDunno/*"] = DoSomethingElseMore;
        }

        private void DoSomethingElseMore(JsonMessage obj)
        {
            throw new NotImplementedException();
        }

        private void SomethingFurther(JsonMessage<StaticPrototype> obj)
        {
            throw new NotImplementedException();
        }


        private void DoSomethingElse(JsonMessage<StaticPrototype> obj)
        {
            throw new NotImplementedException();
        }

        private void DoSomething(JsonMessage jsonMessage)
        {
            throw new NotImplementedException();
        }
    }
}
