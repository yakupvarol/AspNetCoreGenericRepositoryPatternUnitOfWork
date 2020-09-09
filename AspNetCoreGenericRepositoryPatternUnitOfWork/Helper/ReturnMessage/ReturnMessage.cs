using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebNewsApi.Helpers.ReturnMessage
{
    public class ReturnModel
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
    }

    public class ReturnData : ReturnModel
    {
        public ReturnData()
        {
            Success = true;
            Code = 200;
            Message = "Everthing is OK";
        }
        public object Data { get; set; }
    }

    public class ReturnList : ReturnModel
    {
        public ReturnList()
        {
            Success = true;
            Code = 200;
            Message = "Everthing is OK";
        }
        public DataList Data { get; set; }
    }

    public class DataList
    {
        public int pageSize { get; set; }
        public int page { get; set; }
        public long itemCount { get; set; }
        public object items { get; set; }
    }

    public class ReturnNotFound : ReturnModel
    {
        public ReturnNotFound()
        {
            Success = true;
            Code = 200;
            Message = "Not Found";
        }
    }

    public class ReturnError : ReturnModel
    {
        public ReturnError()
        {
            Success = false;
            Code = 500;
            Message = "An error has occurred in the system.";
        }
        public string InternalMessage { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ReturnErrorModel> Errors { get; set; }
    }

    public class ReturnErrorModel
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public string InternalMessage { get; set; }
    }
}
