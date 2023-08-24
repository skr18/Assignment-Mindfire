using FuelManagementSystem.business;
using FuelManagementSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static FuelManagementSystem.utils.CoustomModels;

namespace FuelManagementSystem
{
    
    public partial class AirportFuelManagementSystem : System.Web.UI.Page
    {
        static string logPath = WebConfigurationManager.AppSettings["myLogRecordPath"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                 Response.Redirect("loginpage?InvalidUrl=true");
            }

        }

        [System.Web.Services.WebMethod]
        public static void InitializeData()
        {
            ApplicationDataInitializeBusiness.InitializeData();
           /* ClientScript.RegisterStartupScript(this.GetType(), "alert", 
                "alert('All your newly added airport's aircraft's and all your transaction will be deleted')", true);*/
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
        ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<string> GetAllAirports()
        {
            List<string> AllAirports = new List<string>();
            try
            {
               AllAirports= AirportsDataBusiness.GetAllAirports();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return AllAirports;
        }

        [System.Web.Services.WebMethod]
        public static List<CoustomModels.AircraftModel> GetAllAircraft(string airportName)
        {
            //List<string> AllCountry = new List<string>();
            if(airportName.Split(',').Length == 1)
            {
                return null;
            }
            var name = airportName.Split(',')[1];
            List<CoustomModels.AircraftModel> AllAircraft = new List<CoustomModels.AircraftModel>();
            try
            {
                AllAircraft = AirportsDataBusiness.GetAllAircraft(name);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return AllAircraft;
            
        }

        [System.Web.Services.WebMethod]
        public static void InsertNewAirport(CoustomModels.AirportModel airportData)
        {
            AirportsDataBusiness.InsertNewAirport(airportData);
        }
       
        [System.Web.Services.WebMethod]
        public static void InsertNewAircraft(CoustomModels.AircraftModel aircraftData)
        {
            AirportsDataBusiness.InsertNewAircraft(aircraftData);
        }


        [System.Web.Services.WebMethod]
        public static bool Transaction(CoustomModels.TransactionModel transactionDatas)
        {
            return TransactionBusiness.Transaction(transactionDatas);
        }

        [System.Web.Services.WebMethod]
        public static int GetFuelCapacity(string airportName)
        {
            int quantity=0;
            try
            {
                quantity = TransactionBusiness.GetFuelCapacity(airportName);
            }catch(Exception ex)
            {

                LogRecords.LogRecord(ex, logPath);
            }
            return quantity;
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
        ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<AirportSummaryModel> GetSummaryReport()
        {
            List< AirportSummaryModel > summaryReport = new List< AirportSummaryModel >();
            try
            {
               summaryReport = ReportBusiness.GetSummaryReport();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return summaryReport;
        }


        [System.Web.Services.WebMethod]
        public static List<AirportFuelReportModel> GetFuelReport(string startDate,string endDate)
        {
            List<AirportFuelReportModel> fuelReport = new List<AirportFuelReportModel>();

            try
            {
                fuelReport = ReportBusiness.GetFuelReport(startDate,endDate);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return fuelReport;
        }

    }
}