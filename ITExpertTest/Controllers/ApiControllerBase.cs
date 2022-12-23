using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ITExpertTest.Controllers;

public class ApiControllerBase : ControllerBase

{
    private readonly ILogger _logger;

    public ApiControllerBase(ILogger logger)
    {
        _logger = logger;
    }
    
    protected void LogEnter(object? parameters = null)
    {
        var json = JsonConvert.SerializeObject(parameters);
        _logger.LogTrace("Enter in {Path} with parameters: {Parameters}", HttpContext.Request.Path.Value, json);
    }
    
    protected void LogLeave(object result)
    {
        var json = JsonConvert.SerializeObject(result);
        _logger.LogTrace("Leaving {Path} with result {Result}", HttpContext.Request.Path.Value, json);
    }
}