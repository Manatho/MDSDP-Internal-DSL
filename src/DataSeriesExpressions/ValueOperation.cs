namespace MDSDP_Internal_DSL
{
    public class ValueOperation : DataSeriesExpression
    {
        private double value;

        public ValueOperation(double value)
        {
            this.value = value;
        }

        public override double Calculate(double[][] data, int index)
        {
            return value;
        }
    }
}
