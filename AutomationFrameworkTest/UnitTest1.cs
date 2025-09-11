namespace AutomationFramework
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Test2()
        {
            Assert.That("Fede", Is.EqualTo("Camila"));
        }

        [Test]
        public void Test3()
        {
            int expected = 42;
            int sum = 40 + 2;
            Assert.That(sum, Is.EqualTo(expected));
        }
    }
}