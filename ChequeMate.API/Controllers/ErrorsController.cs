using ChequeMate.API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace ChequeMate.API.Controllers;

[Route("errors/{code}")]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : BaseApiController
{
    public IActionResult Error(int code)
    {
        return new ObjectResult(new ApiResponse(code));
    }
}