using Common.Contracts;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Persistence
{
    public class DataManager : IDataStore
    {
        //Temp repo of data
        private static List<RecordDetail> Records = new List<RecordDetail>();

        public IEnumerable<RecordDetail> GetRecords()
        {
            return Records;
        }

        public RecordDetail SaveRecord(RecordDetail record)
        {
            Records.Add(record);
            return record;
        }
    }
}
