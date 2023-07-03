using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{

    public QuizController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok();
    }
}
