using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>The interface for describing provider methods</summary>
    public interface IProvider
    {
        /// <summary>A polymorphic method for obtaining converted values regardless of input..</summary>
        /// <param name="parser">The parser.</param>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        object GetValue(IParser parser, dynamic input);

        /// <summary>Gets the type input value.</summary>
        /// <returns></returns>
        Type GetTypeInputValue();
    }
}
