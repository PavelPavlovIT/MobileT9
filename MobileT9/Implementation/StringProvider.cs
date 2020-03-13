using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    /// <summary>The provider implementation if  input of string data</summary>
    /// <seealso cref="Core.IProvider" />
    public class StringProvider: IProvider
    {
        #region Public methods
        /// <summary>Returns type string.</summary>
        /// <returns></returns>
        public Type GetTypeInputValue()
        {
            return String.Empty.GetType();
        }

        /// <summary>  A polymorphic method for obtaining converted values ​​for input string data..</summary>
        /// <param name="parser">The parser.</param>
        /// <param name="input">The input as string.</param>
        /// <returns></returns>
        public object GetValue(IParser parser, dynamic input)
        {
            return parser.Parse(input);
        }
        #endregion region
    }
}
