using KanzWay.Services;
using Microsoft.AspNetCore.Mvc;
namespace KanzWay.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ScreeningController : ControllerBase
{
    private readonly IScreeningService _screeningService;

    public ScreeningController(IScreeningService screeningService)
    {
        _screeningService = screeningService;
    }

    [HttpGet("{number}")]
    public ActionResult<List<string>> GetScreeningList(int number)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { Errors = errors });
            }

            var screeningList = _screeningService.GetScreeningList(number);
            return Ok(screeningList);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
