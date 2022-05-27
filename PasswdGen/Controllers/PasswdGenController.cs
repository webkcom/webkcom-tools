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
        public string getResult(bool containNumbers, bool containUppercase,bool containLowercase, bool containSpchar, int strLength, int count)
        {
            PasswdGenService request = new PasswdGenService();
            return request.passwdGen(containNumbers,containUppercase,containLowercase,containSpchar,strLength,count);
        }
    }
}