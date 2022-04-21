using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareenWebApi.Dtos
{
    public class DataResponse
    {

        public bool IsSuccess { get; set; }
        public int AffectedRecords { get; set; }
        public int TotalRecords { get; set; }
        public string EndUserMessage { get; set; }
        public Exception Exception { get; set; }
    }
}