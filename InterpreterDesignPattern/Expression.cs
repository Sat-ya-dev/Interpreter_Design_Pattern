using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterDesignPattern
{
    public interface IExpression
    {
        void Evaluate(Context context);
    }

    public class LowerCaseExpression : IExpression
    {
        public void Evaluate(Context context)  
        {
            if (context.Value != null)
            {
                context.Value = context.Value.ToLower();
            }
        }
    }

    public class UpperCaseExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            if (context.Value != null)
            {
                context.Value = context.Value.ToUpper();
            }
        }
    }

    public class ReverseExpression : IExpression
    {
        public void Evaluate(Context context)
        {
            if (context.Value != null)
            {
                context.Value = new string(context.Value.Reverse().ToArray());
            }
        }
    }
}
