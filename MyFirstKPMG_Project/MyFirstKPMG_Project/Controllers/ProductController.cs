using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyFirstKPMG_Project.Models;
using OfficeOpenXml;
using MyFirstKPMG_Project.Filters;

namespace MyFirstKPMG_Project.Controllers
{
    [AuthenticationFilter]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            DARSHANEntities2 db = new DARSHANEntities2();
            List<tblProduct> ViewResult = db.tblProducts.ToList();
            return View(ViewResult);
        }

        public ActionResult Detail(int? id)
        {
            DARSHANEntities2 db = new DARSHANEntities2();
            tblProduct ViewResult_ById = db.tblProducts.Where(x => x.iProductId == id).FirstOrDefault();

            return View(ViewResult_ById);
        }

        public void Reports()
        {
            DARSHANEntities2 db = new DARSHANEntities2();
            List<tblProduct> ViewResult = db.tblProducts.ToList();

            var memoryStream = new MemoryStream();
            using (ExcelPackage EP = new ExcelPackage(memoryStream))
            {
                ExcelWorksheet EWS = EP.Workbook.Worksheets.Add("Report");

                EWS.Cells["A1"].Value = "Product Details";
                EWS.Cells["A2"].Value = "Date:- ";
                EWS.Cells["B2"].Value = string.Format("{0: dd MMMM yyyy}", DateTime.Now);

                EWS.Cells["A6"].Value = "Product Id";
                EWS.Cells["B6"].Value = "Product Name";
                EWS.Cells["C6"].Value = "Product Category";
                EWS.Cells["D6"].Value = "Product price";
                EWS.Cells["E6"].Value = "Product Date";

                int RowBegin = 7;

                foreach (var item in ViewResult)
                {
                    EWS.Cells[string.Format("A{0}", RowBegin)].Value = item.iProductId;
                    EWS.Cells[string.Format("B{0}", RowBegin)].Value = item.vchProductName;
                    EWS.Cells[string.Format("C{0}", RowBegin)].Value = item.vchProductCategory;
                    EWS.Cells[string.Format("D{0}", RowBegin)].Value = item.decproductPrice;
                    EWS.Cells[string.Format("E{0}", RowBegin)].Value = item.dtPurchaseDate;

                    RowBegin++;
                }

                EWS.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
                Response.BinaryWrite(EP.GetAsByteArray());
                Response.End();
            }
        }
    }
}