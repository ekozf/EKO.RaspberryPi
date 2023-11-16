using EKO.RaspberryPi.AppLogic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EKO.RaspberryPi.Api.Controllers;

[Route("/api")]
public class ServerController : Controller
{
    private readonly IServerDetailsService _serverDetailsService;
    private readonly IArticleHandler _articleHandler;

    public ServerController(IServerDetailsService serverDetailsService, IArticleHandler articleHandler)
    {
        _serverDetailsService = serverDetailsService;
        _articleHandler = articleHandler;
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

    [HttpGet("get-article/{articleName}")]
    public IActionResult GetBlogArticle(string articleName)
    {
        var fileStream = _articleHandler.GetBlogArticleAsMarkdown(articleName);

        if (fileStream == null)
            return NotFound("Given file name was not found.");

        return File(fileStream, "application/octet-stream", articleName);
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
