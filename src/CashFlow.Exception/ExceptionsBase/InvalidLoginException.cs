﻿
using System.Net;

namespace CashFlow.Exception.ExceptionsBase
{
    public class InvalidLoginException : CashFlowException
    {
        public InvalidLoginException() : base(ResourceErrorMessage.EMAIL_OR_PASSWORD_INVALID)
        {
        }

        public override int StatusCode => (int)HttpStatusCode.Unauthorized;

        public override List<string> GetErros()
        {
            return [Message];
        }
    }
}
