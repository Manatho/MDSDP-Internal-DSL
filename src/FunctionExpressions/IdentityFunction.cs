namespace MDSDP_Internal_DSL
{
    public class IdentityFunction : FunctionExpression
    {
        private double value;

        public IdentityFunction(double value)
        {
            this.value = value;
        }

        public override double Execute(double[][] data)
        {
            return value;
        }
    }
}
