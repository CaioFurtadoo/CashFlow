
using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using ClosedXML.Excel;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel
{
    public class GenerateExpenseReportsExcelUseCase : IGenerateExpenseReportsExcelUseCase
    {
        private readonly IExpenseReadOnlyRepository _repository;
        private readonly ILoggedUser _loggedUser;
        public GenerateExpenseReportsExcelUseCase(IExpenseReadOnlyRepository repository, ILoggedUser logged)
        {
            _repository = repository;
            _loggedUser = logged;
        }

        public async Task<byte[]> Execute(DateOnly month)
        {
            var loggedUser = await _loggedUser.Get();
            var expenses = await _repository.FilterByMonth(loggedUser, month);

            if(expenses.Count == 0)
            {
                return [];
            }

            var workbook = new XLWorkbook();
            workbook.Author = "Caio";
            workbook.Style.Font.FontSize = 12;

            var  workSheet = workbook.Worksheets.Add(month.ToString("Y"));

            InsertHeader(workSheet);

            var raw = 2;
            foreach( var expense in expenses)
            {
                workSheet.Cell($"A{raw}").Value = expense.Title;
                workSheet.Cell($"B{raw}").Value = expense.Date;
                workSheet.Cell($"C{raw}").Value = ConvertPaymentType(expense.PaymentType);
                workSheet.Cell($"D{raw}").Value = expense.Amount;
                workSheet.Cell($"E{raw}").Value = expense.Description;
                raw++;
            }

            workSheet.Columns().AdjustToContents();

            var file = new MemoryStream();
            workbook.SaveAs(file);

            return file.ToArray();
        }

        private string ConvertPaymentType(PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Cash => "Dinheiro",
                PaymentType.CreditCard => "Cartão de Credito",
                PaymentType.DebitCard => "Cartão de Debito",
                PaymentType.EletronicTransfer => "Transferencia Bancaria",
                _ => string.Empty,
            };
        }

        private void InsertHeader(IXLWorksheet workSheet)
        {
            workSheet.Cell("A1").Value = ResourceReportMessage.TITLE;
            workSheet.Cell("B1").Value = ResourceReportMessage.DATE;
            workSheet.Cell("C1").Value = ResourceReportMessage.PAYMENT_TYPE;
            workSheet.Cell("D1").Value = ResourceReportMessage.AMOUNT;
            workSheet.Cell("E1").Value = ResourceReportMessage.DESCRIPTION;

            workSheet.Cells("A1:E1").Style.Font.Bold = true;
            workSheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.Green;
            workSheet.Cells("A1:E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        }
    }
}
