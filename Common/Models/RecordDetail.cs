using Common.Contracts;
using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class RecordDetail : ISortable<RecordDetail>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }
        public string FavColor { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// override the tostring to the desired format; 
        /// Helps in printing out the result
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}", LastName, FirstName, Gender, FavColor, DateOfBirth.ToString("M/d/yyyy"));
        }

        public Func<RecordDetail,object> FetchPropDelegate(string propName)
        {
            switch (propName)
            {
                case "LastName": return model => model.LastName;
                case "FirstName": return model => model.FirstName;
                case "Gender": return model => model.Gender;
                case "FavColor": return model => model.FavColor;
                case "DateOfBirth": return model => model.DateOfBirth;
                default: return null;
            }
        }

      
    }
}
