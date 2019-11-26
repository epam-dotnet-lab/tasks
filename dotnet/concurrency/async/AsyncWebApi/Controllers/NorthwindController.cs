using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AsyncWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NorthwindController : Controller
    {
        private readonly HttpClient httpClient = new HttpClient();
        private readonly string[] endpointUrls;

        public NorthwindController(IConfiguration configuration)
        {
            var serviceUrl = configuration.GetValue<string>("ServiceUrl");
            var endpointsStr = configuration.GetValue<string>("Endpoints");
            var endpoints = endpointsStr.Split(',', StringSplitOptions.RemoveEmptyEntries);
            this.endpointUrls = endpoints.Select(e => serviceUrl + e).ToArray();
        }

        [HttpGet("async")]
        public async Task<IActionResult> GetAsync()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (string endpointUrl in endpointUrls)
            {
                await this.httpClient.GetAsync(endpointUrl);
            }

            stopwatch.Stop();

            return this.Ok(new
            {
                stopwatch.ElapsedMilliseconds
            });
        }

        [HttpGet("waitall")]
        public async Task<IActionResult> GetWaitAll()
        {
            var stopwatch = new Stopwatch();

            var tasks = endpointUrls.Select(u => this.httpClient.GetAsync(u)).ToArray();
            
            stopwatch.Start();

            // TODO - use Task.WhenAll method to await on all tasks.
            // Read more:
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/how-to-extend-the-async-walkthrough-by-using-task-whenall

            stopwatch.Stop();

            return this.Ok(new
            {
                stopwatch.ElapsedMilliseconds
            });
        }
    }
}
