using Core;
using Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NUnitMobile9.Tests
{
    class FileProviderTests
    {
        FileProvider fileProvider = new FileProvider();
        IParser parser = new T9Parser();

        [Test]
        public void GetTypeInputValue()
        {

            string str = "test";
            FileInfo fileInfo = new FileInfo("test");
            Assert.AreEqual(fileInfo.GetType(), fileProvider.GetTypeInputValue());
        }

        [Test]
        public void GetValue()
        {
            FileInfo fileInputSmall = new FileInfo(Directory.GetCurrentDirectory() + "\\in\\C-small-practice.in");
            FileInfo fileInputLarge = new FileInfo(Directory.GetCurrentDirectory() + "\\in\\C-large-practice.in");
            string resultFileSmall = fileProvider.GetValue(parser, fileInputSmall) as string;
            string resultFileLarge = fileProvider.GetValue(parser, fileInputLarge) as string;
            Assert.AreEqual(true, File.Exists(resultFileSmall));
            Assert.AreEqual(true, File.Exists(resultFileLarge));
            Console.WriteLine(resultFileSmall);
            Console.WriteLine(resultFileLarge);
        }
    }
}
