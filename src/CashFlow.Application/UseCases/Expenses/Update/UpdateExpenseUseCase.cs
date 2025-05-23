﻿using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseUpdateOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        public UpdateExpenseUseCase(IMapper mapper, IUnitOfWork unitOfWork, IExpenseUpdateOnlyRepository repository, ILoggedUser loggedUser)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
            _loggedUser = loggedUser;
        }

        public async Task Execute(long id, RequestRegisterExpenseJson request)
        {
            Validate(request);

            var loggedUser = await _loggedUser.Get();

            var expense = await _repository.GetId(loggedUser, id);

            if (expense is null)
            {
                throw new NotFoundException(ResourceErrorMessage.EXPENSE_NOT_FOUND);
            }

            _mapper.Map(request, expense);

            _repository.Update(expense);
            await _unitOfWork.Commit();
        }

        private void Validate(RequestRegisterExpenseJson request)
        {
            var validator = new RegisterExpenseValidator();
            var result = validator.Validate(request);
            
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }

        }
    }
}
