using Common.Contracts;
using Common.Enums;
using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Sorts the inpur list of RecordDetail based on the sortsequence list
        /// sort will be performed in sequence provided by the sortsequence.
        /// </summary>
        /// <param name="records">records that need to be sorted</param>
        /// <param name="sortSequence">list of sort conditions</param>
        /// <returns>list of sorted records</returns>
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> records, IEnumerable<SortSequence> sortSequence) where T : ISortable<T>
        {
            if ((sortSequence == null || sortSequence.Count() == 0) || (records == null || records.Count() == 0)) return records;

            Func<string, Func<T, object>> propFunc = records.First().FetchPropDelegate; 

            //convert enumerable to orderedenumerable
            var orderedEnumerable = records.Where(r => r != null).OrderBy(a => 1);
            var sortedSequence = sortSequence.OrderBy(r => r.Sequence);
            foreach (var order in sortedSequence)
            {
               
                if (propFunc != null)
                    if (order.SortDirection == ListSortDirection.Ascending)
                        orderedEnumerable = orderedEnumerable.ThenBy(propFunc(order.PropName));
                    else
                        orderedEnumerable = orderedEnumerable.ThenByDescending(propFunc(order.PropName));

            }
            return orderedEnumerable.AsEnumerable();
        }
    }
}
