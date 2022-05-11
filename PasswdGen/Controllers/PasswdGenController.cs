using Microsoft.AspNetCore.Mvc;
using PasswdGen.Service;
using Microsoft.AspNetCore.Cors;

namespace PasswdGen.Controllers
{
    [ApiController]
    [EnableCors("default")]
    [Route("api/[controller]")]
    public class PasswdGenController : ControllerBase
    {
        [HttpGet("GetResult")]
        public string getResult(bool containNumbers, bool containLetters, bool containSymbols, int length)
        {
            PasswdGenService request = new PasswdGenService();
            return request.getResult(containNumbers,containLetters,containSymbols,length);
        }
    }
}