using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using student.Models;
using student.Service;

namespace student.Controllers
{
    public class StudentController : Controller
    {
        IStudentServices _studentServices = null;
        List<Student> _students = new List<Student>();

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult SaveStudent(List<Student> students) 
        {
            _students = _studentServices.SaveStudentS(students);
            return Json(_students);
        }

        public string GenerateAndDownloadExcel(int studentId, string name)
        {
            List<Student> students = _studentServices.GetStudentList();
            var dataTable = CommonMethod.ConvertListToDataTable(students);

            //dataTable.Columns.Remove("Id");

            byte[] fileContents = null;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Students");
                ws.Cells["A1"].Value = "School Name";
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A1"].Style.Font.Bold = true;

                ws.Cells["A2"].Value = "Student List";
                ws.Cells["A3"].Style.Font.Bold = true;

                ws.Cells["A3"].LoadFromDataTable(dataTable,true);
                ws.Cells["A3:F3"].Style.Font.Bold = true;
                ws.Cells["A3:F3"].Style.Font.Size = 12;
                //ws.Cells["A3:C3"].Style.Fill.BackgroundColor.SetColor[System.Drawing.Color.SkyBlue];

                pck.Save();
                fileContents = pck.GetAsByteArray();
            }
            return Convert.ToBase64String(fileContents);
        }
    }
}
