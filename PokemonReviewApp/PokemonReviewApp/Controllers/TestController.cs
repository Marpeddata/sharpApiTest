using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {

        private readonly ITest _testRepository;

        public TestController(ITest testRepository)
        {
            _testRepository = testRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<String>))]

        public IActionResult GetTestData()
        {
            var test = _testRepository.GetTestData();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(test);
        }

    }
}
