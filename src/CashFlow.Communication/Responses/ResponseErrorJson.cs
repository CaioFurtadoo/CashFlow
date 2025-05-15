

namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessage { get; set; } = [];

        public ResponseErrorJson(string ErrorMessage)
        {
            this.ErrorMessage = [ErrorMessage];
        }

        public ResponseErrorJson(List<string> ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
    }
}
