using MyFirstKPMG_Project.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.DataVisualization.Charting;

namespace MyFirstKPMG_Project.Controllers
{
    public class ChartsController : Controller
    {
        DARSHANEntities2 db = new DARSHANEntities2();
       
        public ActionResult GetChartProduct()
        {
            
            var data = db.tblProducts.ToList();
            var chart = new Chart();
            var area = new ChartArea();
            chart.ChartAreas.Add(area);
            var series = new Series();
            foreach (var item in data)
            {
                series.Points.AddXY(item.vchProductName, item.decproductPrice);
            }
            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Times New Roman", 500.3443f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Column;
            chart.Series.Add(series);
            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }

        public ActionResult GetChartFruit()
        {
            var data = db.tblFruitsDetails.ToList();
            var chart = new Chart();
            var area = new ChartArea();
            chart.ChartAreas.Add(area);
            var series = new Series();
            foreach (var item in data)
            {
                series.Points.AddXY(item.FruitName, item.FruitPrice);
            }
            series.Label = "#PERCENT{P0}";
            series.Font = new Font("Arial", 8.0f, FontStyle.Bold);
            series.ChartType = SeriesChartType.Line;
            chart.Series.Add(series);
            var returnStream = new MemoryStream();
            chart.ImageType = ChartImageType.Png;
            chart.SaveImage(returnStream);
            returnStream.Position = 0;
            return new FileStreamResult(returnStream, "image/png");
        }
    }
}