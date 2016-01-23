using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FileParser.Utilities;
using System.IO;
using FileParser.Exceptions;
using Common.Models;

namespace FileParser.Tests
{
    [TestFixture]
    public class FileReaderTests
    {
        [Test]
        public void CheckEmptyFilePaths()
        {
            List<string> filePaths = null;
            var expected = new List<string>();
            var actual = FileReader.ReadFiles(filePaths);
            Assert.AreEqual(expected.Count, actual.Count);

        }

        [Test]
        public void CheckFilePaths()
        {
            List<string> filePaths = new List<string> { AppDomain.CurrentDomain.BaseDirectory + @"/TestFiles/csd.txt"};
            var exepected = new List<string> { "devineni,srikanth,male,black,01/02/1985" };
            var actual = FileReader.ReadFiles(filePaths);
            Assert.AreEqual(exepected.Count, actual.Count);
            Assert.AreEqual(exepected.First(), actual.First());

        }


        [Test]
        public void CheckEmptyFilePath()
        {
            string filePath = string.Empty;
            Assert.Throws<FileReadException>(() => FileReader.ReadFile(filePath));

        }

        [Test]
        public void CheckIncorrectFilePath()
        {
            string filePath = "test";
            Assert.Throws<FileNotFoundException>(() => FileReader.ReadFile(filePath));

        }

        [Test]
        public void CheckAndReadValidFile()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"/TestFiles/csd.txt";
            var exepected = new List<string> { "devineni,srikanth,male,black,01/02/1985" };
            var actual = FileReader.ReadFile(filePath);
            Assert.AreEqual(exepected.Count, actual.Count);
            Assert.AreEqual(exepected.First(), actual.First());

        }
    }
}
