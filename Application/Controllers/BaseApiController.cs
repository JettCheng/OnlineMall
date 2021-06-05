using System.Threading.Tasks;
using Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
        // [HttpGet]   // https://localhost:5001/api/baseapi?query=xxx
        // public IActionResult GetQuery( [FromQuery] string query )
        // {
        //     return Ok(query);
        // }

        // [HttpGet("{id}")]   // https://localhost:5001/api/baseapi/xxx
        // public IActionResult GetId( [FromRoute] string id )
        // {
        //     return Ok(id);
        // }

        // [HttpPost]  // https://localhost:5001/api/baseapi
        // public IActionResult Post( [FromBody] TestDto body )
        // {
        //     return Ok(body);
        // }
    }
}