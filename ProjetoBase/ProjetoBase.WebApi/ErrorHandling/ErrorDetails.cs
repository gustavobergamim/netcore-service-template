using Newtonsoft.Json;

namespace ProjetoBase.WebApi.ErrorHandling
{
    public class ErrorDetails
    {
        public int StatusCode { get; }
        public string Message { get; }

        public ErrorDetails(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static implicit operator string(ErrorDetails details)
        {
            return details.ToString();
        }
    }
}
