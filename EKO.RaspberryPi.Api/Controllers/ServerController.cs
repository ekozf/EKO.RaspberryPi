using EKO.RaspberryPi.Api.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EKO.RaspberryPi.Api.Controllers;

[Route("/api")]
public class ServerController : Controller
{
    private readonly IServerDetailsService _serverDetailsService;

    public ServerController(IServerDetailsService serverDetailsService)
    {
        _serverDetailsService = serverDetailsService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return Content("Hello from EKO.RaspberryPi.Api!");
    }

    [HttpGet("repeat")]
    public IActionResult Repeat(string msg)
    {
        return Content("You said: " + msg);
    }

    [HttpGet("version")]
    public IActionResult Version(bool prettify)
    {
        var details = _serverDetailsService.GetServerDetails();

        if (prettify)
        {
            var builder = new StringBuilder();

            builder
                .Append("Version: ")
                .AppendLine(details.Version.ToString())
                .Append($"OS: ")
                .AppendLine(details.OS)
                .Append($"Framework: ")
                .AppendLine(details.Framework)
                .Append($"Timestamp: ")
                .AppendLine(details.Timestamp.ToString())
                .Append($"Uptime: ")
                .AppendLine(details.Uptime.ToString());

            return Content(builder.ToString());
        }

        return Json(details);
    }
}
