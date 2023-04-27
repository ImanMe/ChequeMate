using FluentValidation;

namespace ChequeMate.API.Features.Invoice.Commands.CreateInvoice;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("CustomerName cannot be empty")
            .Length(1, 100).WithMessage("CustomerName should be between 2 and 100 characters");

        RuleFor(x => x.DueDate)
            .NotEmpty().WithMessage("DueDate cannot be empty.")
            .Must(BeValidDueDate).WithMessage("DueDate should be a valid date, greater than the current date and time.");

        RuleFor(x => x.ListItems)
            .Must(listItems => listItems != null && listItems.Any()).WithMessage("ListItems cannot be empty.");
    }

    private bool BeValidDueDate(string dueDate)
    {
        if (DateTime.TryParse(dueDate, out var parsedDueDate))
        {
            return parsedDueDate >= DateTime.Now;
        }

        return false;
    }
}
