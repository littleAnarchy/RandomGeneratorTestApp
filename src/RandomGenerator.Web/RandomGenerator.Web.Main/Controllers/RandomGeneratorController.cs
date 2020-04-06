using Microsoft.AspNetCore.Mvc;
using RandomGenerator.Shared.ApiModels.Responses;
using RandomGenerator.Web.Services.Interfaces;

namespace WebRandomGeneraterTestApp.Controllers
{
    [ApiController]
    [Route("random")]
    public class RandomGeneratorController : ControllerBase
    {
        private readonly IRandomGenerator _generator;

        public RandomGeneratorController(IRandomGenerator generator)
        {
            _generator = generator;
        }

        [HttpGet]
        [Route("get")]
        public IActionResult GetRandomValue()
        {
            try
            {
                var value = _generator.GetRandomValue();
                return Ok(new GetRandomResponse { Value = value });
            }
            catch
            {
                return BadRequest("Service temporarily unavailable");
            }
        }
    }
}
