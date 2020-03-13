using Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NUnitMobile9.Tests
{
    class ProviderTests
    {
        [Test]
        public void Add()
        {
            Provider provider = new Provider(new T9Parser());
            provider.Add(new StringProvider());
            Assert.AreEqual(1, provider.Providers.Count);
        }

        [Test]
        public void Remove()
        {
            Provider provider = new Provider(new T9Parser());
            provider.Add(new StringProvider());
            provider.Remove(new StringProvider());
            Assert.AreEqual(0, provider.Providers.Count);
        }

        [Test]
        public void DoubleAdditionException()
        {
            Provider provider = new Provider(new T9Parser());
            provider.Add(new StringProvider());
            try
            {
                provider.Add(new StringProvider());
            }
            catch (Exception ex)
            {
                string[] arr = ex.Message.Split(':');
                Assert.AreEqual("The provider exists in dictionary", arr[0]);
            }
        }

        [Test]
        public void GetResult()
        {
            Provider provider = new Provider(new T9Parser());
            provider.Add(new StringProvider());
            provider.Add(new ArrayProvider());

            string inputStr = "hi";
            Assert.AreEqual(inputStr.GetType(), provider.GetResult(inputStr).GetType());
            Assert.AreEqual("44 444", provider.GetResult(inputStr));
            string[] arr = { "hi", "yes", "foo  bar", "hello world" };
            Assert.AreEqual(arr.GetType(), provider.GetResult(arr).GetType());
            Assert.AreEqual("44 444", (provider.GetResult(arr) as string[])[0]);
            FileInfo fileInputSmall = new FileInfo(Directory.GetCurrentDirectory() + "\\in\\C-small-practice.in");
            try
            {
                var resfile = provider.GetResult(fileInputSmall) as string;
                Assert.AreEqual(true, File.Exists(resfile));
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Unregistered input type", ex.Message);
            }
            provider.Add(new FileProvider());
            var resfile1 = provider.GetResult(fileInputSmall) as string;
            Assert.AreEqual(true, File.Exists(resfile1));

        }
    }
}
