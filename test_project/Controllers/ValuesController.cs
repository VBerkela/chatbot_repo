using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_project.Models;
using test_project.Services;

namespace test_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

    

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("Hello World");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatBotParametrs value)
        {
           
            if (value.Utterance.ToLower() == "hi"|| value.Utterance.ToLower() == "hello")
            {
                return Ok("{\"prediction\":{ \"topIntent\": \"Hello!\"}}");
            }
             try
            {
                var result = await CallBotService.MakeRequest(value.Utterance);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
