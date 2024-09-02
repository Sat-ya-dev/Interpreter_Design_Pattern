using Microsoft.VisualStudio.TestTools.UnitTesting;
using InterpreterDesignPattern;

namespace InterpreterDesignPattern.Tests
{
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void TestLowerCaseExpression()
        {
            // Arrange
            var context = new Context("-l", "Hello World");
            var interpreter = new Interpreter();

            // Act
            interpreter.Interpret(context);

            // Assert
            Assert.AreEqual("hello world", context.Value);
        }

        [TestMethod]
        public void TestUpperCaseExpression()
        {
            var context = new Context("-u", "Hello World");
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            Assert.AreEqual("HELLO WORLD", context.Value);
        }

        [TestMethod]
        public void TestReverseExpression()
        {

            var context = new Context("-r", "Hello World");
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            Assert.AreEqual("dlroW olleH", context.Value);
        }

        [TestMethod]
        public void TestMultipleExpressions()
        {
            var context = new Context("-l -r", "Hello");
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            Assert.AreEqual("olleh", context.Value);
        }
                
        [TestMethod]
        public void TestInvalidExpression()
        {
            var context = new Context("-x", "Hello World");
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            // Here we would expect no change to the context value since the expression is invalid.
            Assert.AreEqual("Hello World", context.Value);
        }

        [TestMethod]
        public void TestNullString()
        {
            var context = new Context("-l", null);
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            Assert.IsNull(context.Value); // Expecting the value to remain null
        }

        [TestMethod]
        public void TestStringContainingNumbersWithLowerCaseExpression()
        {
            var context = new Context("-l", "HeLLo123");
            var interpreter = new Interpreter();

            interpreter.Interpret(context);

            // Numbers should remain unchanged, while letters are lowercased
            Assert.AreEqual("hello123", context.Value); 
        }
    }
}
