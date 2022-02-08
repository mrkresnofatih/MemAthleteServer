namespace MemAthleteServer.Utils
{
    public class ResponsePayload
    {
        public string ErrorCode { get; set; }
        public object Data { get; set; }
    }

    public static class ResponseHandler
    {
        public static ResponsePayload wrapSuccess(object data)
        {
            return new ResponsePayload {Data = data, ErrorCode = null};
        }

        public static ResponsePayload wrapFailure(string errorCode)
        {
            return new ResponsePayload {ErrorCode = errorCode, Data = null};
        }
    }
}