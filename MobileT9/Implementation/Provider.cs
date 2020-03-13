using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation
{
    /// <summary>The class for converting text input in the format T9 (as on mobile phone)</summary>
    public class Provider
    {
        #region fields
        /// <summary>The dictionary providers for converting different input data</summary>
        private readonly Dictionary<Type, IProvider> providers;

        /// <summary>The parser
        /// (converter)</summary>
        private IParser parser;

        #endregion

        #region properties
        /// <summary>Gets the providers.</summary>
        /// <value>The providers.</value>
        public Dictionary<Type, IProvider> Providers => providers;
        #endregion 

        #region constructors
        /// <summary>Initializes a new instance of the <see cref="Provider"/> class.</summary>
        /// <param name="parser">The parser.</param>
        public Provider(IParser parser)
        {
            this.providers = new Dictionary<Type, IProvider>();
            this.parser = parser;
        }
        #endregion

        /// <summary>Adds the specified provider to dictionary of providers. .</summary>
        /// <param name="provider">The provider.</param>
        /// <exception cref="Exception">The provider exists in dictionary: Message: " + ex.Message
        /// or
        /// Error when adding provider to dictionary. Message: " + ex.Message</exception>
        public void Add(IProvider provider)
        {
            try
            {
                this.providers.Add(provider.GetTypeInputValue(), provider);
            }
            catch (ArgumentException ex)
            {
                throw new Exception("The provider exists in dictionary: Message: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error when adding provider to dictionary. Message: " + ex.Message);
            }
        }

        /// <summary>Removes the specified provider from dictionary of providers. .</summary>
        /// <param name="provider">The provider.</param>
        /// <exception cref="Exception">Error when removing provider from dictionary. Message: " + ex.Message</exception>
        public void Remove(IProvider provider)
        {
            try
            {
                this.providers.Remove(provider.GetTypeInputValue());
            }
            catch (Exception ex)
            {
                throw new Exception("Error when removing provider from dictionary. Message: " + ex.Message);
            }
        }

        /// <summary>Gets the result of the conversion.</summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Unregistered input type</exception>
        public object GetResult(object input)
        {
            if (!providers.ContainsKey(input.GetType()))
            {
                throw new Exception("Unregistered input type");
            }
            return providers[input.GetType()].GetValue(this.parser, input);
        }
    }
}
