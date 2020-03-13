using Core;
using Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitMobile9.Tests
{
    class ArrayProviderTests
    {
        ArrayProvider arrayProvider = new ArrayProvider();
        IParser parser = new T9Parser();

        [Test]
        public void GetTypeInputValue()
        {
            string[] arrStr = { "test", "test" };
            Assert.AreEqual(arrStr.GetType(), arrayProvider.GetTypeInputValue());
        }

        [Test]
        public void GetValue()
        {
            string[] arr = { "hi", "yes", "foo  bar", "hello world" };
            Assert.AreEqual("44 444", (arrayProvider.GetValue(parser, arr) as string[])[0]);
            Assert.AreEqual("999337777", (arrayProvider.GetValue(parser, arr) as string[])[1]);
            Assert.AreEqual("333666 6660 022 2777", (arrayProvider.GetValue(parser, arr) as string[])[2]);
            Assert.AreEqual("4433555 555666096667775553", (arrayProvider.GetValue(parser, arr) as string[])[3]);
        }
    }
}
