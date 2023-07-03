using Microsoft.AspNetCore.Mvc;

namespace QuizApi.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{

    public QuestionController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok();
    }
}
