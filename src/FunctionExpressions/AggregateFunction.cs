using System;
using System.Collections.Generic;

namespace MDSDP_Internal_DSL
{
    public delegate double AggregationMethod(double newValue, double aggregated);

    // Linking element between the two types (FunctionExpression and DataSeriesExpression)
    // Takes an AggregationMethod delegate to ease customizability. Could and should be elaborated
    // support more interesting methods such as Average.
    public class AggregateFunction : FunctionExpression
    {
        private readonly DataSeriesExpression dataSeriesTerm;
        private readonly AggregationMethod aggregationMethod;
        private readonly double initialValue;

        public AggregateFunction(DataSeriesExpression operation, AggregationMethod method, double initialValue = 0)
        {
            this.initialValue = initialValue;
            this.dataSeriesTerm = operation;
            this.aggregationMethod = method;
        }

        public override double Execute(double[][] data)
        {
            var runningValue = initialValue;
            var index = 0;
            foreach (var entry in data)
            {
                runningValue = aggregationMethod(dataSeriesTerm.Calculate(data, index), runningValue);
                index++;
            }
            return runningValue;
        }
    }
}
