using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using FuelManagementSystem.utils;
using FuelManagementSystem.business;

namespace FuelManagementSystem
{
    public partial class AirportSummaryDownload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void FuelReportImageButton_Click(object sender, ImageClickEventArgs e)
        {
            var startDate = startDateUserHandle.Text;
            var endDate = endDateUserHandle.Text;
           using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                BaseFont headingFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font titleFont = new Font(headingFont, 20, Font.BOLD);
                Font headingTitleFont = new Font(headingFont, 12, Font.ITALIC);
                Font normalFont = new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12);
                BaseColor titleColor = new BaseColor(41, 128, 185);
                BaseColor tableHeaderColor = new BaseColor(189, 195, 199);

                Paragraph title = new Paragraph("Fuel Reports", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20f;
                document.Add(title);



                List<CoustomModels.AirportFuelReportModel> airportFuelReportModels = ReportBusiness.GetFuelReport(startDate,"2023-08-24");
                int previousId = -1;


                CoustomModels.AirportFuelReportModel airportFuelReport;
                PdfPTable table= new PdfPTable(4);
                for (int i=0;i<airportFuelReportModels.Count;)
                {
                    airportFuelReport = airportFuelReportModels[i];
                    
                    if(airportFuelReportModels[i].AirportId!=previousId)
                    {
                       
                        table = new PdfPTable(4);
                        
                        table.DefaultCell.BorderWidth = 1;
                        table.DefaultCell.Padding = 5;
                        table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                        table.AddCell(new Phrase("Date", normalFont));
                        table.AddCell(new Phrase("Type", normalFont));
                        table.AddCell(new Phrase("Fuel", normalFont));
                        table.AddCell(new Phrase("Aircraft No", normalFont));

                        Paragraph airportName = new Paragraph($"Airport - {airportFuelReport.AirportName}", headingTitleFont);
                        airportName.SpacingAfter = 20f;
                        document.Add(airportName);
                        previousId = airportFuelReport.AirportId;
                    }

                    while (i < airportFuelReportModels.Count && previousId == airportFuelReportModels[i].AirportId )
                    {
                        airportFuelReport = airportFuelReportModels[i];
                        table.AddCell(new Phrase(airportFuelReport.TransactionDate, normalFont));
                        table.AddCell(new Phrase(airportFuelReport.TransactionType, normalFont));
                        table.AddCell(new Phrase(airportFuelReport.Quantity.ToString(), normalFont));
                        table.AddCell(new Phrase(airportFuelReport.AircraftName, normalFont));
                        i++;

                    }
                    if (i == airportFuelReportModels.Count || previousId != airportFuelReportModels[i].AirportId)
                    {
                        document.Add(table);

                        Paragraph airportFuelAvailable = new Paragraph($"Fuel Available - {airportFuelReportModels[i-1].FuelAvailability}", headingTitleFont);
                        airportFuelAvailable.SpacingBefore = 20f;
                        airportFuelAvailable.SpacingAfter = 20f;
                        document.Add(airportFuelAvailable);

                        Paragraph newlinePattern = new Paragraph("----------------", headingTitleFont);
                        newlinePattern.SpacingBefore = 10f;
                        newlinePattern.SpacingAfter = 20f;
                        document.Add(newlinePattern);
                    }

                }

               

                document.Close();
                Response.Clear();
                Response.BufferOutput = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=FuelReports.pdf");
                Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush();
                Response.End();
            }
        }

        protected void summaryReportImageButton_Click(object sender, ImageClickEventArgs e)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                BaseFont headingFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font titleFont = new Font(headingFont, 18, Font.BOLD);
                Font normalFont = new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12);
                BaseColor titleColor = new BaseColor(41, 128, 185);
                BaseColor tableHeaderColor = new BaseColor(189, 195, 199);

                Paragraph title = new Paragraph("Summmary Reports", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 20f;
                document.Add(title);



                PdfPTable table = new PdfPTable(2);
                //table.DefaultCell.BackgroundColor = tableHeaderColor;
                table.DefaultCell.BorderWidth = 1;
                table.DefaultCell.Padding = 5;
                table.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

                table.AddCell(new Phrase("AirportName", normalFont));
                table.AddCell(new Phrase("Fuel Available", normalFont));

                List<CoustomModels.AirportSummaryModel> airportSummaries = ReportBusiness.GetSummaryReport();
                foreach (var airportSummary in airportSummaries)
                {
                    table.AddCell(new Phrase(airportSummary.AirportName, normalFont));
                    table.AddCell(new Phrase(airportSummary.FuelAvailability.ToString(), normalFont));
                }



                document.Add(table);

                document.Close();
                Response.Clear();
                Response.BufferOutput = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "attachment; filename=SummaryReports.pdf");
                Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush();
                Response.End();
            }

        }
    }
}