using System.Data;

namespace student.Repository
{
    public interface IBulkLedger
    {
        string DocumentUpload(IFormFile formFile);

        DataTable BulkLedgerDataTable(String path);

        void ImportBulkLedger(DataTable BulkLedger);
    }
}
