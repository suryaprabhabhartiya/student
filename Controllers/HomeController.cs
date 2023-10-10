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

namespace student.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult Index(List<Student> students = null)
    {
        students = students == null ? new List<Student>() : students;
        return View(students);
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

    [HttpPost]
    public IActionResult Index(IFormFile postedFile)//, [FormServices] IHostingEnvironment hostingEnvironment)
    {
        //List<Student> students=new List<Student>();
        //    string wwwPath = this.Environment.WebRootPath;
        //    string contentPath = this.Environment.ContentRootPath;
        //string filenamePath = $"{hostingEnvironment.WebRootPath}\\Uploads\\{postedFile.FileName}";
        //string filenamePath = Path.Combine("E:\\surya\\icloud assingment\\student\\wwwroot\\Uploads",postedFile.FileName);
        //string path = Path.Combine(hostingEnvironment.WebRootPath, "Uploads");
        string path = "E:\\surya\\icloud assingment\\student\\wwwroot\\Uploads";
        // string path = "E:\\surya\\icloud assingment\\student\\Uploads";
        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);
        //}
        string fileName = Path.GetFileName(postedFile.FileName);
        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        {
            postedFile.CopyTo(stream);
            //uploadedFiles.Add(fileName);
            stream.Flush();


            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);

        }
        var student = this.GetStudentList(postedFile.FileName);


        return View(student);
    }

    private List<Student> GetStudentList(string filenamestu)
    {
        List<Student> students = new List<Student>();
        string filenamePath = Path.Combine("E:\\surya\\icloud assingment\\student\\wwwroot\\Uploads", filenamestu);
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using (var streamread = System.IO.File.Open(filenamePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(streamread))
            {
                while (reader.Read())
                {
                    students.Add(new Student()
                    {
                        Id = reader.GetValue(0).ToString(),
                        stuName = reader.GetValue(1).ToString(),
                        fName = reader.GetValue(2).ToString(),
                        Mname = reader.GetValue(3).ToString(),
                        DOB = reader.GetValue(4).ToString(),
                        Mnumber = reader.GetValue(5).ToString()
                    });
                }

            }

        }
        return students;
    }

    //[HttpPost]
    //public ActionResult Index(HttpPostedFileBase postedFile)
    //{
    //    string filePath = string.Empty;
    //    if (postedFile != null)
    //    {
    //        string path = Server.MapPath("~/Uploads/");
    //        if (!Directory.Exists(path))
    //        {
    //            Directory.CreateDirectory(path);
    //        }

    //        filePath = path + Path.GetFileName(postedFile.FileName);
    //        string extension = Path.GetExtension(postedFile.FileName);
    //        postedFile.SaveAs(filePath);

    //        string conString = string.Empty;
    //        switch (extension)
    //        {
    //            case".xls": //Excel 97-03.
    //                conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
    //                break;
    //            case".xlsx": //Excel 07 and above.
    //                conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
    //                break;
    //        }

    //        DataTable dt = new DataTable();
    //        conString = string.Format(conString, filePath);

    //        using (OleDbConnection connExcel = new OleDbConnection(conString))
    //        {
    //            using (OleDbCommand cmdExcel = new OleDbCommand())
    //            {
    //                using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
    //                {
    //                    cmdExcel.Connection = connExcel;

    //                    //Get the name of First Sheet.
    //                    connExcel.Open();
    //                    DataTable dtExcelSchema;
    //                    dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    //                    string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    //                    connExcel.Close();

    //                    //Read Data from First Sheet.
    //                    connExcel.Open();
    //                    cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
    //                    odaExcel.SelectCommand = cmdExcel;
    //                    odaExcel.Fill(dt);
    //                    connExcel.Close();                           
    //                }
    //            }
    //        }

    //        conString = ConfigurationManager.ConnectionStrings["Constring"].ConnectionString;
    //        using (SqlConnection con = new SqlConnection(conString))
    //        {
    //            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
    //            {
    //                //Set the database table name.
    //                sqlBulkCopy.DestinationTableName = "dbo.Customers";

    //                //[OPTIONAL]: Map the Excel columns with that of the database table
    //                sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
    //                sqlBulkCopy.ColumnMappings.Add("Name", "Name");
    //                sqlBulkCopy.ColumnMappings.Add("Country", "Country");

    //                con.Open();
    //                sqlBulkCopy.WriteToServer(dt);
    //                con.Close();
    //            }
    //        }
    //    }

    //    return View();
    //} 


}
