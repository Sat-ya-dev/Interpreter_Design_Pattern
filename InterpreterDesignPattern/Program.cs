using InterpreterDesignPattern;
using System.Diagnostics.Tracing;

Console.WriteLine("Provide a word with expression");
var word = Console.ReadLine();

if (word != null && word.Contains("-"))
{
    var value = word.Substring(0, word.IndexOf("-"));
    var expressions = word.Substring(word.IndexOf("-")); 

    var interpreter = new Interpreter();
    interpreter.Interpret(new Context(expressions, value));
}
else if (word == null)
{
    //if you did not type anything
    throw new Exception("You did not type anything");
}
else 
{
    // you just gave the string but not the expression
    throw new Exception("You forgot to add expression. Try adding -l or -u after the string.");
}