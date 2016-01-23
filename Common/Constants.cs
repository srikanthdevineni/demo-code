using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        //possible delimiters
        public static readonly char[] fileDelimiters = new char[] { ' ', '|', ',' };

        public const int LastNameOrderSequence = 0;
        public const int FirstNameOrderSequence = 1;
        public const int GenderOrderSequence = 2;
        public const int FavColorOrderSequence = 3;
        public const int DateOfBirthOrderSequence = 4;


    }
}
