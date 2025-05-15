using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.GetId
{
    public class GetIdExpenseUseCase : IGetIdExpenseUseCase
    {
        public readonly IMapper _mapper;
        public readonly IExpenseReadOnlyRepository _repository;
        public GetIdExpenseUseCase(IExpenseReadOnlyRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseExpenseJson> Execute(long id)
        {
            var result = await _repository.GetId(id);

            if(result is null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            return _mapper.Map<ResponseExpenseJson>(result);
        }
    }
}
