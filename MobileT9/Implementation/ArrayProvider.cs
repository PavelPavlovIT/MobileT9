using Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Implementation
{
    /// <summary>The provider implementation if  input of array of strings data</summary>
    /// <seealso cref="Core.IProvider" />
    public class ArrayProvider : IProvider
    {
        /// <summary>Returns type array of strings.</summary>
        /// <returns></returns>
        public Type GetTypeInputValue()
        {
            String[] result = { };
            return result.GetType();
        }

        /// <summary>A polymorphic method for obtaining converted values ​​for input array of strings data.</summary>
        /// <param name="parser">The parser.</param>
        /// <param name="input">The input as array of strings.</param>
        /// <returns></returns>
        public object GetValue(IParser parser, dynamic input)
        {
            string[] result = new string[input.Length];
            int idx = 0;
            string[] temp = input as string[];
            Parallel.ForEach(temp, (value, pls, index) =>
            {
                result[index] = parser.Parse(input[index]);
                index++;
            });
            return result;
        }

    }
}
