using CashFlow.Exception.ExceptionsBase;
using CashFlow.Exception;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.DeleteId
{
    public class DeleteIdExpenseUseCase : IDeleteExpenseUseCase
    {
        public readonly IExpenseDeleteOnlyRepository _repository;
        public readonly IUnitOfWork _unitOfWork;
        public  DeleteIdExpenseUseCase(IExpenseDeleteOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _repository.DeleteId(id);

            if (result == false)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            await _unitOfWork.Commit();
        }
    }
}
