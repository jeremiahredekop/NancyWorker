using NUnit.Framework;

namespace NancyMessageHandler.Tests.Support
{
    public class SpecificationBase
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }
        protected virtual void Given()
        { }
        protected virtual void When()
        { }

        

        
    }
}