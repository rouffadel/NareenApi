using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareenWebApi.Dtos
{
    public class ResponseVM
    {
        public string Status { set; get; }
        public string Message { set; get; }
        public Object content { set; get; }
        //public List<string> content = new List<string>();
    }
}