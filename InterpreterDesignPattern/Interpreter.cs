using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterDesignPattern
{
    public class Interpreter
    {
        public void Interpret(Context context) 
        {
            if (context == null || context.Expression == null)
            {
                Console.WriteLine("Error: Invalid context or expression.");
                return;
            }
            var expressions = context.Expression.Split(' ');
            var expressionTypes = new List<IExpression>();

            foreach (var expression in expressions)
            {
                if (expression == "-l") 
                    expressionTypes.Add(new LowerCaseExpression());
                else if (expression == "-u")
                    expressionTypes.Add(new UpperCaseExpression());
                else if (expression == "-r")
                    expressionTypes.Add(new ReverseExpression());
                else
                    Console.WriteLine("Invalid expression");
            }

            foreach (var item in expressionTypes) 
            {
                item.Evaluate(context);            
            }
            Console.WriteLine(context.Value);
        }
    }
}
