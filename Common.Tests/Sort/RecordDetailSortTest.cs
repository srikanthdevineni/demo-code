using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Common.Models;
using Common.Enums;
using System.ComponentModel;
using Common.Extensions;
using Common.Tests.ListComparers;

namespace Common.Tests.Sort
{
    [TestFixture]
    public class RecordDetailSortTest
    {
        private IEnumerable<SortSequence> _emptySortList;
        private IEnumerable<SortSequence> _nullSortList;
        private IEnumerable<SortSequence> _sortList;
        private IEnumerable<SortSequence> _sort1List;
        private IEnumerable<SortSequence> _sort2List;
        private IEnumerable<SortSequence> _sort3List;

        private IEnumerable<RecordDetail> _emptyInputList;
        private IEnumerable<RecordDetail> _nullInputList;
        private IEnumerable<RecordDetail> _inputList;

        [OneTimeSetUp]
        public void init()
        {
            _emptySortList = new List<SortSequence>();
            _nullInputList = null;
            _sortList = new List<SortSequence>() { 
                 new SortSequence{ PropName = RecordDetailEnum.Gender.ToString(), Sequence = 1, SortDirection = ListSortDirection.Ascending},
             new SortSequence{ PropName = RecordDetailEnum.LastName.ToString(), Sequence = 2, SortDirection = ListSortDirection.Ascending},
              new SortSequence{ PropName = RecordDetailEnum.DateOfBirth.ToString(), Sequence = 3, SortDirection = ListSortDirection.Descending}
            };

            _sort1List = new List<SortSequence>() { 
                 new SortSequence{ PropName = RecordDetailEnum.Gender.ToString(), Sequence = 1, SortDirection = ListSortDirection.Descending},
             new SortSequence{ PropName = RecordDetailEnum.LastName.ToString(), Sequence = 2, SortDirection = ListSortDirection.Descending},
              new SortSequence{ PropName = RecordDetailEnum.DateOfBirth.ToString(), Sequence = 3, SortDirection = ListSortDirection.Ascending}
            };

            _sort2List = new List<SortSequence>() { 
                 new SortSequence{ PropName = RecordDetailEnum.FirstName.ToString(), Sequence = 1, SortDirection = ListSortDirection.Descending},
             new SortSequence{ PropName = RecordDetailEnum.FavColor.ToString(), Sequence = 2, SortDirection = ListSortDirection.Ascending}
            };

            _sort3List = new List<SortSequence>() { 
                 new SortSequence{ PropName = RecordDetailEnum.FirstName.ToString(), Sequence = 1, SortDirection = ListSortDirection.Ascending},
             new SortSequence{ PropName = RecordDetailEnum.FavColor.ToString(), Sequence = 2, SortDirection = ListSortDirection.Descending}
            };

            _emptyInputList = new List<RecordDetail>();
            _nullInputList = null;
            _inputList = new List<RecordDetail>(){
                new RecordDetail{ LastName = "devineni", FirstName = "srikanth", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1985,1,1), FavColor = "Green", Gender = "Male"},
                 new RecordDetail{ LastName = "alastair", FirstName = "cook", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Yellow", Gender = "Female"},
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Blue", Gender = "Female"},
                new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1986,1,1), FavColor = "Red", Gender = "Male"}
            };
        }

        [Test]
        public void SortNullList()
        {
            IEnumerable<RecordDetail> expected = _nullInputList;
            var actual = _nullInputList.Sort( _sortList);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortEmptyList()
        {
            IEnumerable<RecordDetail> expected = _emptyInputList;
            var actual = _emptyInputList.Sort( _sortList);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByNullList()
        {
            IEnumerable<RecordDetail> expected = _inputList;
            var actual = _inputList.Sort(_nullSortList);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByEmptyList()
        {
            IEnumerable<RecordDetail> expected = _inputList;
            var actual = _inputList.Sort( _emptySortList);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SortList()
        {
            List<RecordDetail> expected = new List<RecordDetail>()
            {
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Yellow", Gender = "Female"},
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Blue", Gender = "Female"},
              new RecordDetail{ LastName = "alastair", FirstName = "cook", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
               new RecordDetail{ LastName = "devineni", FirstName = "srikanth", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1986,1,1), FavColor = "Red", Gender = "Male"},
                  new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1985,1,1), FavColor = "Green", Gender = "Male"}
           
         
            };
            var actual = _inputList.Sort( _sortList).ToList();
            CollectionAssert.AreEqual(expected, actual, new RecordDetailComparer());
        }

        [Test]
        public void Sort1List()
        {
            List<RecordDetail> expected = new List<RecordDetail>()
            {
                  new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1985,1,1), FavColor = "Green", Gender = "Male"},
                   new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1986,1,1), FavColor = "Red", Gender = "Male"},
                  new RecordDetail{ LastName = "devineni", FirstName = "srikanth", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                new RecordDetail{ LastName = "alastair", FirstName = "cook", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
              new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Yellow", Gender = "Female"},
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Blue", Gender = "Female"}
             
           
            };
            var actual = _inputList.Sort( _sort1List).ToList();
            CollectionAssert.AreEqual(expected, actual, new RecordDetailComparer());
        }

        [Test]
        public void Sort2List()
        {
            List<RecordDetail> expected = new List<RecordDetail>()
            {
                
                  new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Blue", Gender = "Female"},
                 new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Yellow", Gender = "Female"},
                  new RecordDetail{ LastName = "devineni", FirstName = "srikanth", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
               new RecordDetail{ LastName = "alastair", FirstName = "cook", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                  new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1985,1,1), FavColor = "Green", Gender = "Male"},
              new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1986,1,1), FavColor = "Red", Gender = "Male"}
                
            };
            var actual =_inputList.Sort( _sort2List).ToList();
            CollectionAssert.AreEqual(expected, actual, new RecordDetailComparer());
        }

        [Test]
        public void Sort3List()
        {
            List<RecordDetail> expected = new List<RecordDetail>()
            {
              new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1986,1,1), FavColor = "Red", Gender = "Male"},
                  new RecordDetail{ LastName = "michael", FirstName = "clarke", DateOfBirth = new DateTime(1985,1,1), FavColor = "Green", Gender = "Male"},
               new RecordDetail{ LastName = "alastair", FirstName = "cook", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                new RecordDetail{ LastName = "devineni", FirstName = "srikanth", DateOfBirth = new DateTime(2000,1,1), FavColor = "Black", Gender = "Male"},
                new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Yellow", Gender = "Female"},
                new RecordDetail{ LastName = "Racheal", FirstName = "weisz", DateOfBirth = new DateTime(1967,1,1), FavColor = "Blue", Gender = "Female"},
                
               
                
            };
            var actual = _inputList.Sort(_sort3List).ToList();
            CollectionAssert.AreEqual(expected, actual, new RecordDetailComparer());
        }


    }
}
