using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AsyncWebApi.Controllers
{
    // TODO - these actions use blocking Task functionality. Use async/await functionality instead.
    // Read more:
    // https://blog.stephencleary.com/2017/03/aspnetcore-synchronization-context.html
    [ApiController]
    [Route("[controller]")]
    public class BlockingController : Controller
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string serviceUrl;

        public BlockingController(IConfiguration configuration)
        {
            this.serviceUrl = configuration.GetValue<string>("ServiceUrl");
        }

        [HttpGet("result")]
        public IActionResult GetWithResult()
        {
            // TODO - replace Result getter with async/await.
            var result = this.httpClient.GetAsync(this.serviceUrl + "Orders").Result;
            
            return this.Ok(new
            {
                result
            });
        }

        [HttpGet("getresult")]
        public IActionResult GetWithGetResult()
        {
            // TODO - replace GetResult() method call with async/await.
            var result = this.httpClient.GetAsync(this.serviceUrl + "Orders").GetAwaiter().GetResult();
            
            return this.Ok(new
            {
                result
            });
        }

        [HttpGet("wait")]
        public IActionResult GetWithWait()
        {
            var task = this.httpClient.GetAsync(this.serviceUrl + "Orders");

            // TODO - replace Wait method call with async/await.
            task.Wait();
            
            return this.Ok(new
            {
                result = task.Result
            });
        }
    }
}
