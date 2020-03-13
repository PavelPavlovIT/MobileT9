using Core;
using Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitMobile9.Tests
{
    class StringProviderTests
    {
        StringProvider stringProvider = new StringProvider();
        IParser parser = new T9Parser();

        [Test]
        public void GetTypeInputValue()
        {
            
            string str = "test";
            Assert.AreEqual(str.GetType(), stringProvider.GetTypeInputValue());
        }

        [Test]
        public void GetValue()
        {
            Assert.AreEqual("44 444", stringProvider.GetValue(parser, "hi"));
            Assert.AreEqual("999337777", stringProvider.GetValue(parser, "yes"));
            Assert.AreEqual("333666 6660 022 2777", stringProvider.GetValue(parser, "foo  bar"));
            Assert.AreEqual("4433555 555666096667775553", stringProvider.GetValue(parser, "hello world"));
        }
    }
}
