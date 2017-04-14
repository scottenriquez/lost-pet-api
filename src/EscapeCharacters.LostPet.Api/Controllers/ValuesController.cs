using System.Web.Http;

namespace EscapeCharacters.LostPet.Api.Controllers
{
    [RoutePrefix("api/test")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [Route("helloWorld")]
        public string HelloWorld()
        {
            return "Hello, world!";
        }
    }
}
