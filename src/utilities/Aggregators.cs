namespace MDSDP_Internal_DSL
{
    //Builder functions for aggregation methods for cleaner DSL syntax
    public static class Aggregators
    {
        public static FunctionExpression Sum(DataSeriesExpression operation)
        {
            return new AggregateFunction(operation, (double newValue, double aggregated) => newValue + aggregated);
        }

        public static FunctionExpression Max(DataSeriesExpression operation)
        {
            return new AggregateFunction(operation, (double newValue, double aggregated) => newValue > aggregated ? newValue : aggregated, double.MinValue);
        }

        public static FunctionExpression Min(DataSeriesExpression operation)
        {
            return new AggregateFunction(operation, (double newValue, double aggregated) => newValue < aggregated ? newValue : aggregated, double.MaxValue);
        }
    }
}