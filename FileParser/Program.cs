using Common.Models;
using FileParser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using Common.Mappers;
using Common.Extensions;
using Common.Enums;
using System.ComponentModel;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            try
            {
                var records = FileReader.ReadFiles(args.ToList());

                var recordDetails = records.Select(RecordDetailMapper.MapDelimitedFileLineToRecordDetail);

                //option 1
                Console.WriteLine("------Option 1-------");
                recordDetails.Sort( new List<SortSequence>{
                     new SortSequence{ PropName = RecordDetailEnum.Gender.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 1},
                     new SortSequence{ PropName = RecordDetailEnum.LastName.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 2}
                }).ToList().ForEach(x => Console.WriteLine(x.ToString()));

                //option 2
                Console.WriteLine("------Option 2-------");
                recordDetails.Sort(new List<SortSequence>{
                     new SortSequence{ PropName = RecordDetailEnum.DateOfBirth.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 1}
                }).ToList().ForEach(x => Console.WriteLine(x.ToString()));

                //option 3
                Console.WriteLine("------Option 3-------");
                recordDetails.Sort(new List<SortSequence>{
                     new SortSequence{ PropName = RecordDetailEnum.LastName.ToString(), SortDirection = ListSortDirection.Descending, Sequence = 1}
                }).ToList().ForEach(x => Console.WriteLine(x.ToString()));


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
