using ChequeMate.API.DTOs;

namespace ChequeMate.API.Features.Invoice.Commands.MarkAsPaid
{
    public class MarkAsPaidResponse : BaseResponse
    {
        public MarkAsPaidResponse(bool success, string message) : base(success, message)
        {
        }
    }
}
