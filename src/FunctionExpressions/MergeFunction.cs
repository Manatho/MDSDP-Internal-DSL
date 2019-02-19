namespace MDSDP_Internal_DSL
{
    // Handles nesting of FunctionExpression and the order of which they happen, 
    // -> builds up the expression tree
    public class MergeFunction : FunctionExpression
    {
        private FunctionExpression first;
        private FunctionExpression second;
        private OperationType operation;

        public MergeFunction(FunctionExpression functionExpression, double value, OperationType type)
        : this(functionExpression, new IdentityFunction(value), type) { }

        public MergeFunction(double value, FunctionExpression functionExpression, OperationType type)
        : this(new IdentityFunction(value), functionExpression, type) { }

        public MergeFunction(FunctionExpression first, FunctionExpression second, OperationType operation)
        {
            this.first = first;
            this.second = second;
            this.operation = operation;
        }

        public override double Execute(double[][] data)
        {
            var first = this.first.Execute(data);
            var second = this.second.Execute(data);
            return OperationHelper.Calculate(first, second, operation);
        }
    }
}
