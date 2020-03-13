using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    /// <summary>The parser implementation for converting input data to a format T9</summary>
    /// <seealso cref="Core.IParser" />
    public class T9Parser : IParser
    {
        #region fields
        /// <summary>The map
        /// of convertetions</summary>
        private Dictionary<char, string> map;
        #endregion

        #region constructors
        /// <summary>Initializes a new instance of the <see cref="T9Parser"/> class.</summary>
        public T9Parser()
        {
            map = new Dictionary<char, string>
                        {
                            { ' ', "0,1" },
                            { 'a', "2,2" },
                            { 'b', "22,2" },
                            { 'c', "222,2" },
                            { 'd', "3,3" },
                            { 'e', "33,3" },
                            { 'f', "333,3" },
                            { 'g', "4,4" },
                            { 'h', "44,4" },
                            { 'i', "444,4" },
                            { 'j', "5,5" },
                            { 'k', "55,5" },
                            { 'l', "555,5" },
                            { 'm', "6,6" },
                            { 'n', "66,6" },
                            { 'o', "666,6" },
                            { 'p', "7,7" },
                            { 'q', "77,7" },
                            { 'r', "777,7" },
                            { 's', "7777,7" },
                            { 't', "8,8" },
                            { 'u', "88,8" },
                            { 'v', "888,8" },
                            { 'w', "9,9" },
                            { 'x', "99,9" },
                            { 'y', "999,9" },
                            { 'z', "9999,9" }
                        };
        }
        #endregion

        #region Public Methods
        /// <summary>Parses the specified input and return string in T9 format.</summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public string Parse(string input)
        {
            var strBuilder = new StringBuilder();
            var btn = "";
            foreach (var c in input.ToCharArray())
            {
                if (map.TryGetValue(c, out var _map))
                {
                    var arr = _map.Split(',');
                    var value = arr[0];
                    var _btn = arr[1];
                    if (btn == _btn)
                    {
                        strBuilder.Append(" ");
                    }

                    btn = _btn;
                    strBuilder.Append(value);
                }

            }
            return strBuilder.ToString();
        }
        #endregion


    }
}
