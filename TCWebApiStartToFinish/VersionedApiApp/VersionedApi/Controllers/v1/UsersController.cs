using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VersionedApi.Controllers.v1;
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0", Deprecated = true)]
public class UsersController : ControllerBase
{
    // GET: api/<UserssController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "Version 1 value1", "Version 1 value2" };
    }

    //// GET api/<UserssController>/5
    //[HttpGet("{id}")]
    //public string Get(int id)
    //{
    //    return "value";
    //}

    //// POST api/<UserssController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    //// PUT api/<UserssController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<UserssController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
