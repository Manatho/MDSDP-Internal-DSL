using System;

namespace MDSDP_Internal_DSL
{
    public enum OperationType
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }

    public static class OperationHelper
    {
        // Probably better to return these as delegates, to avoid repeatetly
        // computing the switch.
        public static double Calculate(double first, double second, OperationType type)
        {
            switch (type)
            {
                case OperationType.Addition:
                    return first + second;
                case OperationType.Subtraction:
                    return first - second;
                case OperationType.Division:
                    return first / second;
                case OperationType.Multiplication:
                    return first * second;
                default:
                    throw new Exception("Invalid operation");
            }
        }
    }
}
