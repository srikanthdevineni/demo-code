using Common.Enums;
using Common.Mappers;
using Common.Models;
using Common.Persistence;
using Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common.Contracts;

namespace Records.API.Controllers
{
    [RoutePrefix("records")]
    public class RecordsController : ApiController
    {

        private IDataStore _dataStore;

        public RecordsController()
        {
            _dataStore = new DataManager();
        }
        /// <summary>
        /// Parse the input string to record and save it
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>parsed and saved RecordDetail object</returns>
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]InputRequest input)
        {
            var errorResponse = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Input");
            if (input == null) return errorResponse;
            var record = RecordDetailMapper.MapDelimitedFileLineToRecordDetail(input.inputLine);
            if (record != null)
            {
                _dataStore.SaveRecord(record);
                return Request.CreateResponse<RecordDetail>(record);
            }
            else
            {
                return errorResponse;

            }
        }

        /// <summary>
        /// gets the  sorted records list by gender
        /// </summary>
        /// <returns>sorted records list by gender</returns>
        [Route("gender")]
        [HttpGet]
        public IEnumerable<RecordDetail> GetSortedByGender()
        {;
            return _dataStore.GetRecords().Sort( new List<SortSequence>{
                 new SortSequence{
                      PropName = RecordDetailEnum.Gender.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 1
                 }
            });
        }

        /// <summary>
        /// gets the  sorted records list by birth date
        /// </summary>
        /// <returns>sorted records list by  birth date</returns>
        [Route("birthdate")]
        [HttpGet]
        public IEnumerable<RecordDetail> GetSortedByBirthDate()
        {
            return _dataStore.GetRecords().Sort( new List<SortSequence>{
                 new SortSequence{
                      PropName = RecordDetailEnum.DateOfBirth.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 1
                 }
            });
        }

        /// <summary>
        /// gets the  sorted records list by last name
        /// </summary>
        /// <returns>sorted records list by last name</returns>
        [Route("name")]
        [HttpGet]
        public IEnumerable<RecordDetail> GetSortedByLastName()
        {
            return _dataStore.GetRecords().Sort( new List<SortSequence>{
                 new SortSequence{
                      PropName = RecordDetailEnum.LastName.ToString(), SortDirection = ListSortDirection.Ascending, Sequence = 1
                 }
            });
        }
    }
}
