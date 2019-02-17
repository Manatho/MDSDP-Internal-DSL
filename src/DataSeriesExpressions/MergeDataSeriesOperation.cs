namespace MDSDP_Internal_DSL
{
    public class MergeDataSeriesOperation : DataSeriesExpression
    {
        public DataSeriesExpression first { get; private set; }
        public DataSeriesExpression second { get; private set; }
        public OperationType operation { get; private set; }

        public MergeDataSeriesOperation(DataSeriesExpression first, DataSeriesExpression second, OperationType operation)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
        }

        public MergeDataSeriesOperation(DataSeriesExpression first, double second, OperationType operation)
        : this(first, new ValueOperation(second), operation) { }

        public MergeDataSeriesOperation(double first, DataSeriesExpression second, OperationType operation)
        : this(new ValueOperation(first), second, operation) { }

        public override double Calculate(double[][] data, int index)
        {
            var value1 = first.Calculate(data, index);
            var value2 = second.Calculate(data, index);

            return OperationHelper.Calculate(value1, value2, operation);
        }
    }
}
