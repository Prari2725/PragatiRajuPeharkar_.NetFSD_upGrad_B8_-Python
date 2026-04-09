namespace UnitTestingDemo.Tests
{
    public class Tests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_ReturnsCorrectSum()
        {
            // Arrange done in Setup()

            // Act
            var result = _calculator.Add(10, 5);

            // Assert
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Divide_ReturnsCorrectResult()
        {
            var result = _calculator.Divide(10, 2);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() =>
                _calculator.Divide(10, 0));
        }
    }
}

