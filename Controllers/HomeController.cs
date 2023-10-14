using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using student.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
//using Microsoft.Extensions.Hosting;
using ExcelDataReader;
using student.Repository;

namespace student.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment _webHostEnvironment;
    private readonly IBulkLedger _bulkLedger;
    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment, IBulkLedger bulkLedger)
    {
        _logger = logger;
        _webHostEnvironment = webHostEnvironment;
        _bulkLedger = bulkLedger;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(IFormFile formFile)
    {
        string path = _bulkLedger.DocumentUpload(formFile);
        DataTable dt = _bulkLedger.BulkLedgerDataTable(path);
        _bulkLedger.ImportBulkLedger(dt);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public IActionResult UploadExceltoDB()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadExceltoDB(List<BulkLedger> bulkLedger)
    {
        //string path = _bulkLedger.DocumentUpload(formFile);
        //DataTable dt = _bulkLedger.BulkLedgerDataTable(path);
        var dt = CommonMethod.ConvertListToDataTable(bulkLedger);
        _bulkLedger.ImportBulkLedger(dt);
        return View();
    }

}
