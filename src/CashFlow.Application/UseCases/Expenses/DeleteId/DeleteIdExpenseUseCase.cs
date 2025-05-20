using CashFlow.Exception.ExceptionsBase;
using CashFlow.Exception;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Expenses.DeleteId
{
    public class DeleteIdExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpenseDeleteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggedUser _loggedUser;
        public  DeleteIdExpenseUseCase(IExpenseDeleteOnlyRepository repository, IUnitOfWork unitOfWork, ILoggedUser logged)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _loggedUser = logged;
        }

        public async Task Execute(long id)
        {
            var loggedUser = await _loggedUser.Get();
            var result = await _repository.DeleteId(loggedUser, id);

            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
