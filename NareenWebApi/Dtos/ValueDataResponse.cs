using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareenWebApi.Dtos
{
    public class ValueDataResponse<T> : DataResponse
    {
        public IEnumerable<T> ListResult { get; set; }
        public T Result { get; set; }
    }
}