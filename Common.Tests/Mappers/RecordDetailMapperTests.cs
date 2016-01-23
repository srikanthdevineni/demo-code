using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Common.Models;
using Common.Mappers;

namespace Common.Tests
{
    [TestFixture]
    public class RecordDetailMapperTests
    {
        [Test]
        public void MapBlankInput()
        {
            string input = null;
            RecordDetail expected = null;
            RecordDetail actual = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input);
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void MapInputStringToRecordDetail()
        {
            string input = "test";
            RecordDetail expected = new RecordDetail
            {
                LastName = "test",
                DateOfBirth = default(DateTime),
                FavColor = default(string),
                FirstName = default(string),
                Gender = default(string)
            };
            RecordDetail actual = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input);
            Assert.AreEqual(AreEqual(expected, actual), true);
        }

        [Test]
        public void MapInputSpaceDelimitedStringToRecordDetail()
        {
            string input = "last first M black 02/04/1999";
            RecordDetail expected = new RecordDetail
            {
                LastName = "last",
                DateOfBirth = Convert.ToDateTime("02/04/1999"),
                FavColor = "black",
                FirstName = "first",
                Gender = "M"
            };
            RecordDetail actual = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input);
            Assert.AreEqual(AreEqual(expected, actual), true);
        }

        [Test]
        public void MapInputPipeDelimitedStringToRecordDetail()
        {
            string input = "last|first|M|black|02/04/1999|X";
            RecordDetail expected = new RecordDetail
            {
                LastName = "last",
                DateOfBirth = Convert.ToDateTime("02/04/1999"),
                FavColor = "black",
                FirstName = "first",
                Gender = "M"
            };
            RecordDetail actual = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input);
            Assert.AreEqual(AreEqual(expected, actual), true);
        }

        [Test]
        public void MapInputCommaDelimitedStringToRecordDetail()
        {
            string input = "last,first,M,black,";
            RecordDetail expected = new RecordDetail
            {
                LastName = "last",
                DateOfBirth = default(DateTime),
                FavColor = "black",
                FirstName = "first",
                Gender = "M"
            };
            RecordDetail actual = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input);
            Assert.AreEqual(AreEqual(expected, actual), true);
        }

        private bool AreEqual(RecordDetail expected, RecordDetail actual)
        {
            return expected.LastName == actual.LastName
                && expected.DateOfBirth == actual.DateOfBirth
                && expected.FirstName == actual.FirstName
                && expected.Gender == actual.Gender
                && expected.FavColor == actual.FavColor;
        }
    }
}
