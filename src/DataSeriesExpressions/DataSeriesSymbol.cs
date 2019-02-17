using System.Collections.Generic;

namespace MDSDP_Internal_DSL
{
    public class DataSeriesSymbol : DataSeriesExpression
    {
        public int index { get; private set; }
        public int offset { get; private set; } = 0;

        public DataSeriesSymbol this[int offset]
        {
            get
            {
                return new DataSeriesSymbol(index, offset);
            }
        }

        public DataSeriesSymbol(int index)
        {
            this.index = index;
        }

        public DataSeriesSymbol(int index, int offset)
        {
            this.index = index;
            this.offset = offset;
        }

        public override double Calculate(double[][] data, int index)
        {
            double[] row;

            if (offset > 0)
            {
                if (index + offset < data.Length)
                    row = data[index + offset];
                else
                    row = data[data.Length - 1];
            }
            else
            {
                if (index + offset > 0)
                    row = data[index + offset];
                else
                    row = data[0];
            }
            return row[this.index];
        }
    }


}
