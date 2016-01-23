using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Exceptions
{
    //custom exception to be thrown while reading a file
    public class FileReadException : Exception
    {
        public FileReadException(string format, params object[] args) : base(string.Format(format, args)) { }
    }
}
