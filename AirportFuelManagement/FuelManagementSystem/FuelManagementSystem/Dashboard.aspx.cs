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
           
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
                ApplicationDataInitializeBusiness.InitializeData();
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
        }

        [WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod(UseHttpGet = true,
        ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
        public static List<string> GetAllAirports()
        {
            List<string> AllAirports = new List<string>();
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
                AllAirports = AirportsDataBusiness.GetAllAirports();
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
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
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
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
                AirportsDataBusiness.InsertNewAirport(airportData);
            }
            catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
        }
       
        [System.Web.Services.WebMethod]
        public static void InsertNewAircraft(CoustomModels.AircraftModel aircraftData)
        {
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
                AirportsDataBusiness.InsertNewAircraft(aircraftData);

            }
            catch(Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);

            }

        }


        [System.Web.Services.WebMethod]
        public static bool Transaction(CoustomModels.TransactionModel transactionDatas)
        {
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
                return TransactionBusiness.Transaction(transactionDatas);

            }catch (Exception ex)
            {
                LogRecords.LogRecord(ex, logPath);
            }
            return false;
        }

        [System.Web.Services.WebMethod]
        public static int GetFuelCapacity(string airportName)
        {
            int quantity=0;
            try
            {
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
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
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"] == null)
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
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
                if (HttpContext.Current.Session == null || HttpContext.Current.Session["UserId"].ToString() == "false")
                {
                    throw new Exception("Someone Trying to acess data without loging");
                }
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