namespace Project.Server.Services
{
    public class Response
    {
        public string Message { get; set; }
        public int Code { get; set; }
        public Object Data { get; set; }

        public Response()
        { }

        public Response(string message, int code)
        {
            this.Message = message;
            this.Code = code;
        }


        public Response(string message, int code, object data)
        {
            this.Message = message;
            this.Code = code;
            this.Data = data;
        }
    }
}