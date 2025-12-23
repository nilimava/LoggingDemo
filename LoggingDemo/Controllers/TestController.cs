using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        // Constructor dependency injection to provide an ILogger instance specific to the TestController.
        // ASP.NET Core automatically injects the appropriate logger.

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
            _logger.LogInformation("LogInformation:TestController started");
        }

        [HttpGet("all-logs")]
        public IActionResult LogAllLevels()
        {
            _logger.LogTrace("LogTrace:Entering the LogAllLevels endpoint with Trace-Level logging");

            //Simulate a variable and log it at trace level
            int cal = 5 * 10;
            _logger.LogTrace($"LogTrace:Calculation :{cal}");

            _logger.LogDebug("LogDebug:Initializing debug-level logs for debugging purpose");
            var debugInfo = new { Action = "LogAllLevel", Status = "Debugging" };

            _logger.LogDebug("LogDebug:Debug Information:{@debugInfo}",debugInfo);

            _logger.LogInformation("LogInformation:The LogAllLevel endpoint was reached successfully");

            //Simulate a condition that might cause an issue
            bool isTakingMoreTime = true;
            if(isTakingMoreTime)
            {
                _logger.LogWarning("LogWarning:External API taking more time to respond.Action may be required now");
            }

            try
            {
                //simulate error scenario
                int x = 0;
                int res = 10/x;

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "LogError:An Error occurred");
            }

            //simulate a critical error scenario
            bool criticalFailure = true;
            if(criticalFailure)
            {
                _logger.LogCritical("LogCritical:A critical system failure has been detected:Immediate attention requires");
            }

            return Ok("All log levels demonstrated");
        }

    }
}
