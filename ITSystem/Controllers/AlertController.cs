using ExcelDataReader;
using ITSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text;

namespace ITSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Alert> get()
        {
           string fileName = "~/LocalFiles/API_Events_DEV.xlsx";

             //  string fileName = @"c:\Users\Lesego.gaompe\Downloads\API_Events_DEV.xlsx";

        
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            Encoding srcEncoding = Encoding.GetEncoding(1251);

            using (var streamval = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(streamval))
                {

                    var dataset = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,

                        }
                    });

                    List<Alert> AlertList = new List<Alert>();
                    Alert alert = new Alert();

                    if (dataset.Tables.Count > 0)
                    {
                        var dataTable = dataset.Tables[0];
                        Console.WriteLine("Rowns :" + dataTable.Rows.Count);
                        Console.WriteLine("Columns :" + dataTable.Columns.Count);

                        AlertList = dataset.Tables[0].AsEnumerable()
                               .Select(datarow => new Alert
                               {
                                   ID = Convert.ToInt32(datarow["ID"]),
                                   DateTimeStamp = Convert.ToDateTime(datarow["DateTimeStamp"].ToString()),
                                   Source = datarow.Field<string>("Source"),
                                   Type = datarow.Field<string>("Type"),
                                   Title = datarow.Field<string>("Title"),
                                   Data = datarow.Field<string>("Data"),

                               }).ToList();

                      
                    }
                    else
                    {
                        Console.WriteLine("No data on the sheet");
                    }
                 
                    return AlertList;
                };
            }
        }
    }
}
