using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NancyMessageHandler.Tests.Support;
using Rhino.Mocks;

namespace NancyMessageHandler.Tests
{
    [TestFixture]
    public class When_running_workers : SpecificationBase
    {
        private SimpleLoop loop;

        private int _counter;

        protected override void Given()
        {
            _counter = 0;
            loop = new SimpleLoop(OnWorkItem, 10);
        }

        private void OnWorkItem()
        {
            _counter++;
            if (_counter == 5)
                loop.Stop();
        }

        protected override void When()
        {
            loop.Work();
        }

        [Then]
        public void The_counter_should_be_five()
        {
            _counter.Should().Be(5);
        }
    }
}