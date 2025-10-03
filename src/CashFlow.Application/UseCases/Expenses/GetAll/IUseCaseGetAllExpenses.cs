﻿
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public interface IUseCaseGetAllExpenses
{
    Task<ResponseGetAllExpenses> Execute();
}