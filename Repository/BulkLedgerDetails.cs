using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.OleDb;

namespace student.Repository
{
    public class BulkLedgerDetails : IBulkLedger
    {
        private IConfiguration configuration;
        private IWebHostEnvironment webHostEnvironment;

        public BulkLedgerDetails(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }
        public DataTable BulkLedgerDataTable(string path)
        {
            var conStr = configuration.GetConnectionString("excelconnection");
            DataTable datatable = new DataTable();
            conStr = string.Format(conStr, path);
            using (OleDbConnection excelconn = new OleDbConnection(conStr))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    using (OleDbDataAdapter adapterExcel = new OleDbDataAdapter())
                    {
                        excelconn.Open();
                        cmd.Connection = excelconn;
                        DataTable excelschema;
                        excelschema = excelconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        var sheetName = excelschema.Rows[0]["Table_Name"].ToString();
                        excelconn.Close();

                        excelconn.Open();
                        cmd.CommandText = "select * from [" + sheetName + "]";
                        adapterExcel.SelectCommand = cmd;
                        adapterExcel.Fill(datatable);
                        excelconn.Close();


                    }
                }
            }
            return datatable;
        }

        public string DocumentUpload(IFormFile formFile)
        {
            string uploadpath = webHostEnvironment.WebRootPath;
            string dest_Path = Path.Combine(uploadpath, "upload");
            if (!Directory.Exists(dest_Path)) { 
            Directory.CreateDirectory(dest_Path);
            }
            string sourceFile = Path.GetFileName(formFile.FileName);    
            string path = Path.Combine(dest_Path, sourceFile);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
            return path;
        }

        public void ImportBulkLedger(DataTable BulkLedger)
        {
            var sqlConn = configuration.GetConnectionString("sqlconnection");
            using (SqlConnection scon= new SqlConnection(sqlConn)) 
            { 
            using (SqlBulkCopy sqlBulkcopy = new SqlBulkCopy(scon)) 
                {
                    sqlBulkcopy.DestinationTableName = "BulkLedger";
                    sqlBulkcopy.ColumnMappings.Add("Sr.", "Sr");
                    sqlBulkcopy.ColumnMappings.Add("Date", "Date");
                    sqlBulkcopy.ColumnMappings.Add("Academic Year", "Academic_Year");
                    sqlBulkcopy.ColumnMappings.Add("Session", "Session");
                    sqlBulkcopy.ColumnMappings.Add("Alloted Category", "Alloted_Category");
                    sqlBulkcopy.ColumnMappings.Add("Voucher Type", "Voucher_Type");
                    sqlBulkcopy.ColumnMappings.Add("Voucher No.", "Voucher_No");
                    sqlBulkcopy.ColumnMappings.Add("Roll No.", "Roll_No");
                    sqlBulkcopy.ColumnMappings.Add("Admno / UniqueId", "Admno_UniqueId");
                    sqlBulkcopy.ColumnMappings.Add("Status", "Status");
                    sqlBulkcopy.ColumnMappings.Add("Fee Category", "Fee_Category");
                    sqlBulkcopy.ColumnMappings.Add("Faculty", "Faculty");
                    sqlBulkcopy.ColumnMappings.Add("Program", "Program");
                    sqlBulkcopy.ColumnMappings.Add("Department", "Department");
                    sqlBulkcopy.ColumnMappings.Add("Batch", "Batch");
                    sqlBulkcopy.ColumnMappings.Add("Receipt No.", "Receipt_No");
                    sqlBulkcopy.ColumnMappings.Add("Fee Head", "Fee_Head");
                    sqlBulkcopy.ColumnMappings.Add("Due Amount", "Due_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Paid Amount", "Paid_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Concession Amount", "Concession_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Scholarship Amount", "Scholarship_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Reverse Concession Amount", "Reverse_Concession_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Write Off Amount", "Write_Off_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Adjusted Amount", "Adjusted_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Refund Amount", "Refund_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Fund TranCfer Amount", "Fund_TranCfer_Amount");
                    sqlBulkcopy.ColumnMappings.Add("Remarks", "Remarks");

                    scon.Open();
                    sqlBulkcopy.WriteToServer(BulkLedger);
                    scon.Close();
                }
            }
        }


    }
}
