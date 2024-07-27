using BusinessLayer.Abstract;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DreamTravel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamTravel.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IExcelService _excelService;

        public ExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        public List<DestinationModel> DestinationList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using (var c = new Context())
            {
                destinationModels = c.Destinations.Select(x => new DestinationModel
                {
                    Capacity = x.Capacity,
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                }).ToList();
            }
            return destinationModels;
        }
        public ActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Kontenjan";
                workSheet.Cell(1, 3).Value = "Konaklama Süresi";
                workSheet.Cell(1, 4).Value = "Fiyat";

                int rowCount = 2;
                foreach (var x in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = x.City;
                    workSheet.Cell(rowCount, 2).Value = x.Capacity;
                    workSheet.Cell(rowCount, 3).Value = x.DayNight;
                    workSheet.Cell(rowCount, 4).Value = x.Price;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Tur Listesi.xlsx");
                }
            }
        }
        public IActionResult DynamicExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Rapor.xlsx");
        }
    }
}
