using System.Collections.Generic;

namespace MDSDP_Internal_DSL
{
    public abstract class FunctionExpression
    {
        public abstract double Execute(double[][] data);

        public static FunctionExpression operator +(FunctionExpression function, double value)
        {
            return new MergeFunction(function, value, OperationType.Addition);
        }

        public static FunctionExpression operator +(double value, FunctionExpression function)
        {
            return new MergeFunction(value, function, OperationType.Addition);
        }

        public static FunctionExpression operator -(FunctionExpression function, double value)
        {
            return new MergeFunction(function, value, OperationType.Subtraction);
        }

        public static FunctionExpression operator -(double value, FunctionExpression function)
        {
            return new MergeFunction(value, function, OperationType.Subtraction);
        }

        public static FunctionExpression operator /(FunctionExpression function, double value)
        {
            return new MergeFunction(function, value, OperationType.Division);
        }

        public static FunctionExpression operator /(double value, FunctionExpression function)
        {
            return new MergeFunction(value, function, OperationType.Division);
        }

        public static FunctionExpression operator *(FunctionExpression function, double value)
        {
            return new MergeFunction(function, value, OperationType.Multiplication);
        }

        public static FunctionExpression operator *(double value, FunctionExpression function)
        {
            return new MergeFunction(value, function, OperationType.Multiplication);
        }

        public static FunctionExpression operator +(FunctionExpression first, FunctionExpression second)
        {
            return new MergeFunction(first, second, OperationType.Addition);
        }

        public static FunctionExpression operator -(FunctionExpression first, FunctionExpression second)
        {
            return new MergeFunction(first, second, OperationType.Subtraction);
        }

        public static FunctionExpression operator /(FunctionExpression first, FunctionExpression second)
        {
            return new MergeFunction(first, second, OperationType.Division);
        }

        public static FunctionExpression operator *(FunctionExpression first, FunctionExpression second)
        {
            return new MergeFunction(first, second, OperationType.Multiplication);
        }
    }
}
