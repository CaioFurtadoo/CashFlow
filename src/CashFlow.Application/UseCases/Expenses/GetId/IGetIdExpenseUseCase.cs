using CashFlow.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Application.UseCases.Expenses.GetId
{
    public interface IGetIdExpenseUseCase
    {
        Task<ResponseExpenseJson> Execute(long id);
    }
}
