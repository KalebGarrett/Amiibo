using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Amiibo.Web.Models;
using Amiibo.Web.Services;

namespace Amiibo.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AmiiboService _amiiboService;

    public HomeController(ILogger<HomeController> logger, AmiiboService amiiboService)
    {
        _logger = logger;
        _amiiboService = amiiboService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new IndexViewModel();
        model.Amiibos = await _amiiboService.GetAll();
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}