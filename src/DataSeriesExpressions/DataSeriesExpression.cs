using System;
using System.Collections.Generic;

namespace MDSDP_Internal_DSL
{
    public abstract class DataSeriesExpression
    {
        public abstract double Calculate(double[][] data, int index);

        public static DataSeriesExpression operator +(DataSeriesExpression first, DataSeriesExpression second)
        {
            return new MergeDataSeriesOperation(first, second, OperationType.Addition);
        }

        public static DataSeriesExpression operator -(DataSeriesExpression first, DataSeriesExpression second)
        {
            return new MergeDataSeriesOperation(first, second, OperationType.Subtraction);
        }

        public static DataSeriesExpression operator /(DataSeriesExpression first, DataSeriesExpression second)
        {
            return new MergeDataSeriesOperation(first, second, OperationType.Division);
        }

        public static DataSeriesExpression operator *(DataSeriesExpression first, DataSeriesExpression second)
        {
            return new MergeDataSeriesOperation(first, second, OperationType.Multiplication);
        }

        public static DataSeriesExpression operator +(DataSeriesExpression function, double value)
        {
            return new MergeDataSeriesOperation(function, value, OperationType.Addition);
        }

        public static DataSeriesExpression operator +(double value, DataSeriesExpression function)
        {
            return new MergeDataSeriesOperation(value, function, OperationType.Addition);
        }

        public static DataSeriesExpression operator -(DataSeriesExpression function, double value)
        {
            return new MergeDataSeriesOperation(function, value, OperationType.Subtraction);
        }

        public static DataSeriesExpression operator -(double value, DataSeriesExpression function)
        {
            return new MergeDataSeriesOperation(value, function, OperationType.Subtraction);
        }

        public static DataSeriesExpression operator /(DataSeriesExpression function, double value)
        {
            return new MergeDataSeriesOperation(function, value, OperationType.Division);
        }

        public static DataSeriesExpression operator /(double value, DataSeriesExpression function)
        {
            return new MergeDataSeriesOperation(value, function, OperationType.Division);
        }

        public static DataSeriesExpression operator *(DataSeriesExpression function, double value)
        {
            return new MergeDataSeriesOperation(function, value, OperationType.Multiplication);
        }

        public static DataSeriesExpression operator *(double value, DataSeriesExpression function)
        {
            return new MergeDataSeriesOperation(value, function, OperationType.Multiplication);
        }

    }
}
