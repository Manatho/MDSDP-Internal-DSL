using System;
using System.Collections.Generic;
using static MDSDP_Internal_DSL.Aggregators;
using static System.Console;

namespace MDSDP_Internal_DSL
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var data = new double[][] {
                new double[] { 1, 11, 111 },
                new double[] { 2, 22, 222 },
                new double[] { 3, 33, 333 },
                new double[] { 4, 44, 444 }
            };

            // Model and builder:
            // dynamic keyword required to avoid compiler disallowing 
            // Dynamic Reception by using . notation to specify name
            dynamic dataSeriesFunctions = new DataSeriesFunctions();

            var P1 = DataSeriesIndex(1);
            var P2 = DataSeriesIndex(2);
            var P3 = DataSeriesIndex(3);

            // DSL examples:
            //Operator precedence works as one expects, parenthesis are as such required!
            dataSeriesFunctions.SumOfThree = (
                Sum((P1[-1] + P1[0] + P1[+1]) / 3) * 1000
            );

            dataSeriesFunctions.MinOfFirst = (
                Min(P1)
            );

            dataSeriesFunctions.AverageOfMinAndMaxValues = (
                (Max(P1) + Min(P1)) / 2
            );

            //Example without using dynamics:
            dataSeriesFunctions["SumOfTwo"](
                Sum(P1 + P2)
            );

            // Model execution:
            Write("Sum of Three: ");
            WriteLine(dataSeriesFunctions.SumOfThree(data));
            Write("MinOfFirst: ");
            WriteLine(dataSeriesFunctions.MinOfFirst(data));
            Write("AverageOfMinAndMaxValues: ");
            WriteLine(dataSeriesFunctions.AverageOfMinAndMaxValues(data));

            //Without dynamics:
            Write("SumOfTwo: ");
            System.Console.WriteLine(dataSeriesFunctions.call("SumOfTwo", data));

        }

        static DataSeriesSymbol DataSeriesIndex(int index)
        {
            return new DataSeriesSymbol(index - 1);
        }
    }
}
