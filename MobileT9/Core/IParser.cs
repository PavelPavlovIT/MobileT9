using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    /// <summary>The interface for conversion input text to T9</summary>
    public interface IParser
    {
        /// <summary>Parses the specified input.</summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        string Parse(string input);
        
    }
}
