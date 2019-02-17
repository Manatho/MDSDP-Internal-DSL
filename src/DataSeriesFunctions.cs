using System;
using System.Collections.Generic;
using System.Dynamic;

namespace MDSDP_Internal_DSL
{
    public class DataSeriesFunctions : DynamicObject
    {
        private Dictionary<string, FunctionExpression> functions = new Dictionary<string, FunctionExpression>();

        public delegate void AddToDictionary(FunctionExpression function);
        //The non-dynamic approach of adding a function, overrides the indexer on the class, returns a delegate from which
        //the function is added to the dictionary.
        public AddToDictionary this[string name]
        {
            get
            {
                return (FunctionExpression function) =>
                    functions[name] = function;
            }
        }

        public double call(string functionName, double[][] data)
        {
            if (!functions.ContainsKey(functionName))
                throw new Exception("No function exists with that name");

            return functions[functionName].Execute(data);
        }

        // Dynamic behaviour / Dynamic Reception (Fowler) inspired by:
        // https://haacked.com/archive/2009/08/26/method-missing-csharp-4.aspx/ 
        // Requires the use of 'dynamic' type/keyword when creating an instance
        // Enables the syntax: dataSeriesFunctions.functionName = ...
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (value is FunctionExpression)
                functions[binder.Name] = value as FunctionExpression;
            else if (value.IsNumber())
            {
                functions[binder.Name] = new IdentityFunction(Convert.ToDouble(value));
            }
            else
            {
                throw new Exception("Invalid function syntax");
            }
            return true;
        }

        // Enables the syntax: dataSeriesFunctions.functionName(data)
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var data = args[0] as double[][];
            if (functions.ContainsKey(binder.Name) && data != null)
            {
                result = call(binder.Name, data);
                return true;
            }
            throw new Exception("No function exists with that name or data not provided");
        }




    }


}
