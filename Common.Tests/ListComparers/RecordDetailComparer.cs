using Common.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests.ListComparers
{
    //custom comparer used in to check for the equality of objects in  two lists
    public class RecordDetailComparer : IComparer
    {
       
        public int Compare(object x, object y)
        {
            var a = (RecordDetail)x;
            var b = (RecordDetail)y;
            if (a.Gender == b.Gender && a.FavColor == b.FavColor &&
               a.DateOfBirth == b.DateOfBirth && a.LastName == b.LastName && a.FirstName == b.FirstName)
                return 0;
            else return 1;
        }
    }


}
