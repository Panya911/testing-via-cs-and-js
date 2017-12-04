using System;
using FluentAssertions;
using NUnit.Framework;

namespace Testing
{
    internal class Calculator
    {
        private int currentSum;

        public double Result()
        {
            return currentSum;
        }

        public void Add(int number)
        {
            checked
            {
                currentSum += number;
            }
        }
    }

    [TestFixture]
    internal class CalculatorSpec
    {
        [TestFixture]
        public class Sum
        {
            [Test]
            public void Should_return_0_by_default()
            {
                var calc = new Calculator();

                var sum = calc.Result();

                Assert.AreEqual(0, sum);
            }

            [Test]
            public void Should_be_0_by_default_with_fluentAssertions()
            {
                var calc = new Calculator();

                var sum = calc.Result();

                sum.Should().Be(10);
            }
        }

        [TestFixture]
        public class Add
        {
            [TestCase(new[] { 1, 2 }, 3, TestName = "1 + 2 = 3")]
            [TestCase(new[] { 5, 10 }, 15, TestName = "5 + 10 = 15")]
            [TestCase(new[] { 1, 2, 3, 4 }, 10, TestName = "1 + 2 + 3 + 4 = 10")]
            public void Should_add_value_to_sum(int[] numbers, int expectedResult)
            {
                var calc = new Calculator();

                foreach (var number in numbers)
                    calc.Add(number);

                var sum = calc.Result();
                Assert.AreEqual(expectedResult, sum);
            }

            [Test]
            public void Should_fail_if_accumulated_value_overflow()
            {
                var calc = new Calculator();
                calc.Add(int.MaxValue);

                TestDelegate act = () => calc.Add(1);

                Assert.Throws<OverflowException>(act);
            }

            [Test]
            public void Should_fail_if_accumulated_value_overflow_with_fluent_assertions()
            {
                var calc = new Calculator();
                calc.Add(int.MaxValue);

                Action act = () => calc.Add(1);

                act.ShouldThrow<OverflowException>();
            }
        }
    }

    [TestFixture]
    internal class NUnitLifeCycleTests
    {
        [OneTimeSetUp]
        public void BeforeAllTests()
        {
            Console.WriteLine("OneTimeSetUp");
        }

        [SetUp]
        public void BeforeEachTest()
        {
            Console.WriteLine("SetUp");
        }

        [TearDown]
        public void AfterEachTest()
        {
            Console.WriteLine("TearDown");
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            Console.WriteLine("OneTimeTearDown");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("test1");
        }

        [Test]
        public void Test2()
        {
            Console.WriteLine("test2");
        }
    }
}