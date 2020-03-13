using Core;
using Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitMobile9.Tests
{
    class T9ParserTests
    {
        [Test]
        public void Parse()
        {
            T9Parser parser = new T9Parser();
            Assert.AreEqual("44 444", parser.Parse("hi"));
            Assert.AreEqual("999337777", parser.Parse("yes"));
            Assert.AreEqual("333666 6660 022 2777", parser.Parse("foo  bar"));
            Assert.AreEqual("4433555 555666096667775553", parser.Parse("hello world"));
        }
    }
}
