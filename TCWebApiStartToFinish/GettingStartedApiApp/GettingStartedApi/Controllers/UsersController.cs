using Microsoft.AspNetCore.Mvc;

namespace GettingStartedApi.Controllers;

// GET, POST, PUT, PATCH, DELETE

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        List<string> output = new();

        for(int i = 0; i< Random.Shared.Next(2,10); i++)
        {
            output.Add($"Value #:{i+1}");   
        }
        return output;
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return $"Value #{id+1}";
    }

    // Post creates a new record
    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // Updates a whole record (Or possibly create)
    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // PATCH updates part of a record
    [HttpPatch("{id}")]
    public void Patch(int id, [FromBody] string value)
    {
        
    }

    // DELETE deletes a record
    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
