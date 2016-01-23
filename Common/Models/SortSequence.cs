using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Common.Models
{
    public class SortSequence
    {
        public string PropName { get; set; }
        public int Sequence { get; set; }
        public ListSortDirection SortDirection { get; set; }
    }
}
