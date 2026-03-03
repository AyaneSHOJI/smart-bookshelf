using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var books = new[]
        {
            new { Id = 1, Title = "The Pragmatic Programmer", Author = "Andrew Hunt" },
            new { Id = 2, Title = "Clean Code", Author = "Robert C. Martin" }
        };

        return Ok(books);
    }
}
