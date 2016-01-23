using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;

namespace Common.Mappers
{
    public class RecordDetailMapper
    {
        /// <summary>
        /// Maps a string to record detail (string can be line from a file or from an api post)
        /// </summary>
        /// <param name="inputLine">input of type string</param>
        /// <returns>a RecordDetail object</returns>
        public static RecordDetail MapDelimitedFileLineToRecordDetail(string inputLine)
        {
            if (string.IsNullOrEmpty(inputLine))
                return null;
            var delimiter = FindDelimiter(inputLine);
            var recordContents = inputLine.Split(delimiter);
            return new RecordDetail
            {
                LastName = recordContents.CheckIndexAndGetValue<string,string>(Constants.LastNameOrderSequence),
                FirstName = recordContents.CheckIndexAndGetValue<string,string>(Constants.FirstNameOrderSequence),
                Gender = recordContents.CheckIndexAndGetValue<string,string>(Constants.GenderOrderSequence),
                FavColor = recordContents.CheckIndexAndGetValue<string,string>(Constants.FavColorOrderSequence),
                DateOfBirth = Convert.ToDateTime(recordContents.CheckIndexAndGetValue<string,DateTime>(Constants.DateOfBirthOrderSequence))
            };
        }

        /// <summary>
        /// indetify the delimiter from the available options
        /// </summary>
        /// <param name="line">string</param>
        /// <returns>char delimiter</returns>
        private static char FindDelimiter(string line)
        {
            var index = line.IndexOfAny(Constants.fileDelimiters);
            if (index > 0)
                return line[index];
            else
                return ' ';
        }
    }
}
