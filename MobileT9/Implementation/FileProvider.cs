using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Implementation
{
    /// <summary>The provider implementation if  input of file</summary>
    /// <seealso cref="Core.IProvider" />
    public class FileProvider : IProvider
    {
        /// <summary>Returns type array of strings.</summary>
        /// <returns></returns>
        public Type GetTypeInputValue()
        {
            FileInfo file = new FileInfo("temp");
            return file.GetType();
        }

        /// <summary>A polymorphic method for obtaining converted values ​​for input file data.</summary>
        /// <param name="parser">The parser.</param>
        /// <param name="input">The input as FileInfo.</param>
        /// <returns></returns>        
        public object GetValue(IParser parser, dynamic input)
        {
            var outFile = Path.ChangeExtension((input as FileInfo).FullName, ".out");
            var idx = 1;
            using (var sr = new StreamReader(input.FullName))
            {
                using (var sw = new StreamWriter(outFile))
                {
                    while (!sr.EndOfStream)
                    {
                        var convertedRow = parser.Parse(sr.ReadLine());
                        var outputRow = $"Case #{idx}: {convertedRow}";
                        sw.WriteLine(outputRow);
                        idx++;
                    }
                }
            }
            return outFile;
        }
    }
}
