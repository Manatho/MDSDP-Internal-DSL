namespace MDSDP_Internal_DSL
{
    public static class Extensions
    {
        // https://stackoverflow.com/questions/1130698/checking-if-an-object-is-a-number-in-c-sharp
        // Used in DataSeriesFunctions.cs
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }
    }
}