using EKO.RaspberryPi.Api.Extensions;
using EKO.RaspberryPi.AppLogic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EKO.RaspberryPi.Api.Controllers;

[Route("/")]
public class ContentController : Controller
{
    private readonly IServerDetailsService _serverDetailsService;

    public ContentController(IServerDetailsService serverDetailsService)
    {
        _serverDetailsService = serverDetailsService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var details = _serverDetailsService.GetServerDetails();

        return View(details.ToServerDetailsViewModel());
    }
}
