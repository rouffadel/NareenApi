using Fadel.EmailComponent;
using NareenWebApi.Dtos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NareenWebApi.DataAcess
{
    //public class DataAcessRepository
    //{
    //}
    public class DataAcessRepository : IDataAcessRepository
    {
        private readonly IDbConnection _db;
        public static string StrConnection;
        public DataAcessRepository()
        {
            _db = new SqlConnection(ConfigurationManager.ConnectionStrings["FS_Connection"].ConnectionString);
            StrConnection = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }
       
       
           
        

        public object GetYearlySummary(int year)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Montly_BalnceSheet_Reports " + year + " - Method Executed.");
            DataSet ds3 = FS_Helper.INSERTRECORDS("Sp_Yearly_Reports", arrayList3);
            List<YearlySummarry> BSE = new List<YearlySummarry>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                YearlySummarry BS = new YearlySummarry();
                BS.MonthName = ds3.Tables[0].Rows[i]["monthname"].ToString();
                BS.MonthNumber = ds3.Tables[0].Rows[i]["number"].ToString();
                BS.CreditAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["CreditAmt"].ToString());
                BS.DebitAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["DebitAmt"].ToString());
                BS.Diff = Convert.ToDecimal(ds3.Tables[0].Rows[i]["Diff"].ToString());
                BSE.Add(BS);
            }

            return BSE;

        }

        public object GetBookingYearlySummary(int year)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Yearly_BookingReports " + year + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection,"Sp_Yearly_BookingReports", arrayList3.ToArray());
            List<BookingYearlySummarry> BSE = new List<BookingYearlySummarry>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                BookingYearlySummarry BS = new BookingYearlySummarry();
                BS.MonthName = ds3.Tables[0].Rows[i]["monthname"].ToString();
                BS.MonthNumber = ds3.Tables[0].Rows[i]["number"].ToString();
                BS.NoOfBookings = Convert.ToInt32(ds3.Tables[0].Rows[i]["bookings"]);
                BSE.Add(BS);
            }

            return BSE;

        }

        IEnumerable<YearlySummarry> IDataAcessRepository.GetYearlySummary(int year)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BookingYearlySummarry> IDataAcessRepository.GetBookingYearlySummary(int year)
        {
            throw new NotImplementedException();
        }

        public object GetMonthlyDetials(int MonthID, int year)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(MonthID);
            arrayList3.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Montly_BalnceSheet_Reports " + MonthID + " - Method Executed.");
            DataSet ds3 = FS_Helper.INSERTRECORDS("Sp_Montly_BalnceSheet_Reports", arrayList3);
            List<BalanceSheet> BSE = new List<BalanceSheet>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                BalanceSheet BS = new BalanceSheet();
                BS.Name = ds3.Tables[0].Rows[i]["Name"].ToString();
                BS.Date = Convert.ToDateTime(ds3.Tables[0].Rows[i]["Date"].ToString());
                BS.Type = ds3.Tables[0].Rows[i]["Type"].ToString();
                BS.CreditAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["CreditAmt"].ToString());
                BS.DebitAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["DebitAmt"].ToString());
                BS.Diff = Convert.ToDecimal(ds3.Tables[0].Rows[i]["Diff"].ToString());
                BSE.Add(BS);
            }

            return BSE;

        }

        IEnumerable<BalanceSheet> IDataAcessRepository.GetMonthlyDetials(int MonthID, int year)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BookingMonthlySheet> IDataAcessRepository.GetBookingMonthlyDetails(int MonthID, int year)
        {
            throw new NotImplementedException();
        }

        public object GetHallWiseCountByDate()
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(DateTime.Now.AddDays(1));
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -GetHallWiseCountByDate - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "sp_gethallwise", arrayList3.ToArray());
            List<HallWiseCount> BSE = new List<HallWiseCount>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                HallWiseCount BS = new HallWiseCount();
                BS.HallName = ds3.Tables[0].Rows[i]["HallName"].ToString();
                BS.HallId = Convert.ToInt32(ds3.Tables[0].Rows[i]["Id"]);
                BS.TotalCount = Convert.ToInt32(ds3.Tables[0].Rows[i]["TotalCount"]);
              
                BSE.Add(BS);
            }

            return BSE;

        }

        public object SaveDevice(SaveDevice model)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(model.DeviceId);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -SaveDevice  - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_SaveDevice", arrayList3.ToArray());
          

            return "Saved Successfully";

        }

        public object GetHallWiseCountByHallId(int HallId)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(DateTime.Now.AddDays(1));
            arrayList3.Add(HallId);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -GetHallWiseCountByHallId  - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "sp_gethallwisebyhallid", arrayList3.ToArray());
            List<BookingMonthlySheet> BSE = new List<BookingMonthlySheet>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                BookingMonthlySheet BS = new BookingMonthlySheet();
                BS.HallName = ds3.Tables[0].Rows[i]["HallName"].ToString();
                BS.BookingId = Convert.ToInt32(ds3.Tables[0].Rows[i]["Id"]);
                BS.AdditionalAmount = Convert.ToString(ds3.Tables[0].Rows[i]["AdditionalAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["AdditionalAmount"]);
                //BS.AdminRemark= Convert.ToString(ds3.Tables[0].Rows[i]["AdminRemark"]);
                BS.Amount = Convert.ToString(ds3.Tables[0].Rows[i]["Amount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Amount"]);
                BS.Balance = Convert.ToString(ds3.Tables[0].Rows[i]["Balance"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Balance"]);
                BS.CateringAmount = Convert.ToString(ds3.Tables[0].Rows[i]["CateringAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringAmount"]);
                BS.CateringFinalAmt = Convert.ToString(ds3.Tables[0].Rows[i]["CateringFinalAmt"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringFinalAmt"]);
                BS.CateringGST = Convert.ToString(ds3.Tables[0].Rows[i]["CateringGST"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringGST"]);
                BS.CateringTaxAmount = Convert.ToString(ds3.Tables[0].Rows[i]["CateringTaxAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringTaxAmount"]);
                BS.CateringUploadMenu = Convert.ToString(ds3.Tables[0].Rows[i]["CateringUploadMenu"]);
                BS.Costperplate = Convert.ToInt32(ds3.Tables[0].Rows[i]["Costperplate"]);
                BS.CreatedDate = Convert.ToDateTime(ds3.Tables[0].Rows[i]["CreatedDate"]);
                BS.CustomerAddress = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerAddress"]);
                BS.CustomerMobileNo = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerMobileNo"]);
                BS.CustomerName = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerName"]);
                BS.Description = Convert.ToString(ds3.Tables[0].Rows[i]["Description"]);
                BS.Discount = Convert.ToString(ds3.Tables[0].Rows[i]["Discount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Discount"]);
                BS.DiscountByAdmin = Convert.ToString(ds3.Tables[0].Rows[i]["DiscountByAdmin"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["DiscountByAdmin"]);
                BS.FinalAmount = Convert.ToString(ds3.Tables[0].Rows[i]["FinalAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["FinalAmount"]);
                BS.FunctionDate = Convert.ToDateTime(ds3.Tables[0].Rows[i]["FunctionDate"]);
                BS.FunctionTitle = Convert.ToString(ds3.Tables[0].Rows[i]["FunctionTitle"]);
                BS.GST = Convert.ToString(ds3.Tables[0].Rows[i]["GST"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["GST"]);
                BS.Guestcount = Convert.ToInt32(ds3.Tables[0].Rows[i]["Guestcount"]);
                BS.HallId = Convert.ToInt32(ds3.Tables[0].Rows[i]["HallId"]);
                BS.IsCatering = Convert.ToBoolean(ds3.Tables[0].Rows[i]["IsCatering"]);
                BS.Muhurtham = Convert.ToString(ds3.Tables[0].Rows[i]["Muhurtham"]);
                BS.TaxableAmount = Convert.ToString(ds3.Tables[0].Rows[i]["TaxableAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["TaxableAmount"]);
                BS.TimeName = Convert.ToString(ds3.Tables[0].Rows[i]["TimeName"]);
                BS.TimeValue = Convert.ToInt32(ds3.Tables[0].Rows[i]["TimeValue"]);
                BSE.Add(BS);
            }

            return BSE;

        }

        public object GetBookingMonthlyDetails(int MonthID, int year)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(MonthID);
            arrayList3.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_HallBookSheet_Reports " + MonthID + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection,"Sp_HallBookSheet_Reports", arrayList3.ToArray());
            List<BookingMonthlySheet> BSE = new List<BookingMonthlySheet>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                BookingMonthlySheet BS = new BookingMonthlySheet();
                BS.HallName = ds3.Tables[0].Rows[i]["HallName"].ToString();
                BS.BookingId = Convert.ToInt32(ds3.Tables[0].Rows[i]["Id"]);
                BS.AdditionalAmount = Convert.ToString(ds3.Tables[0].Rows[i]["AdditionalAmount"])==""?0:Convert.ToDecimal(ds3.Tables[0].Rows[i]["AdditionalAmount"]);
                //BS.AdminRemark= Convert.ToString(ds3.Tables[0].Rows[i]["AdminRemark"]);
                BS.Amount = Convert.ToString(ds3.Tables[0].Rows[i]["Amount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Amount"]);
                BS.Balance = Convert.ToString(ds3.Tables[0].Rows[i]["Balance"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Balance"]);
                BS.CateringAmount = Convert.ToString(ds3.Tables[0].Rows[i]["CateringAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringAmount"]);
                BS.CateringFinalAmt = Convert.ToString(ds3.Tables[0].Rows[i]["CateringFinalAmt"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringFinalAmt"]);
                BS.CateringGST = Convert.ToString(ds3.Tables[0].Rows[i]["CateringGST"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringGST"]);
                BS.CateringTaxAmount = Convert.ToString(ds3.Tables[0].Rows[i]["CateringTaxAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["CateringTaxAmount"]);
                BS.CateringUploadMenu = Convert.ToString(ds3.Tables[0].Rows[i]["CateringUploadMenu"]);
                BS.Costperplate = Convert.ToInt32(ds3.Tables[0].Rows[i]["Costperplate"]);
                BS.CreatedDate = Convert.ToDateTime(ds3.Tables[0].Rows[i]["CreatedDate"]);
                BS.CustomerAddress = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerAddress"]);
                BS.CustomerMobileNo = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerMobileNo"]);
                BS.CustomerName = Convert.ToString(ds3.Tables[0].Rows[i]["CustomerName"]);
                BS.Description = Convert.ToString(ds3.Tables[0].Rows[i]["Description"]);
                BS.Discount = Convert.ToString(ds3.Tables[0].Rows[i]["Discount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["Discount"]);
                BS.DiscountByAdmin = Convert.ToString(ds3.Tables[0].Rows[i]["DiscountByAdmin"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["DiscountByAdmin"]);
                BS.FinalAmount = Convert.ToString(ds3.Tables[0].Rows[i]["FinalAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["FinalAmount"]);
                BS.FunctionDate = Convert.ToDateTime(ds3.Tables[0].Rows[i]["FunctionDate"]);
                BS.FunctionTitle = Convert.ToString(ds3.Tables[0].Rows[i]["FunctionTitle"]);
                BS.GST = Convert.ToString(ds3.Tables[0].Rows[i]["GST"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["GST"]);
                BS.Guestcount = Convert.ToInt32(ds3.Tables[0].Rows[i]["Guestcount"]);
                BS.HallId = Convert.ToInt32(ds3.Tables[0].Rows[i]["HallId"]);
                BS.IsCatering = Convert.ToBoolean(ds3.Tables[0].Rows[i]["IsCatering"]);
                BS.Muhurtham = Convert.ToString(ds3.Tables[0].Rows[i]["Muhurtham"]);
                BS.TaxableAmount = Convert.ToString(ds3.Tables[0].Rows[i]["TaxableAmount"]) == "" ? 0 : Convert.ToDecimal(ds3.Tables[0].Rows[i]["TaxableAmount"]);
                BS.TimeName = Convert.ToString(ds3.Tables[0].Rows[i]["TimeName"]);
                BS.TimeValue = Convert.ToInt32(ds3.Tables[0].Rows[i]["TimeValue"]);
                BSE.Add(BS);
            }

            return BSE;

        }

        public object GetDailySummary(DateTime Dates)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(Dates);
           
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Montly_BalnceSheet_Reports " + Dates + " - Method Executed.");
            DataSet ds3 = FS_Helper.INSERTRECORDS("Sp_Montly_BalnceSheet_DateWiseReports", arrayList3);
            List<BalanceSheet> BSE = new List<BalanceSheet>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                BalanceSheet BS = new BalanceSheet();
                BS.Name = ds3.Tables[0].Rows[i]["Name"].ToString();
                BS.Date = Convert.ToDateTime(ds3.Tables[0].Rows[i]["Date"].ToString());
                BS.Type = ds3.Tables[0].Rows[i]["Type"].ToString();
                BS.CreditAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["CreditAmt"].ToString());
                BS.DebitAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["DebitAmt"].ToString());
                BS.Diff = Convert.ToDecimal(ds3.Tables[0].Rows[i]["Diff"].ToString());

                BSE.Add(BS);
            }

            return BSE;

        }

        IEnumerable<BalanceSheet> IDataAcessRepository.GetDailySummary(DateTime Dates)
        {
            throw new NotImplementedException();
        }
        public object GetDailyaReport(DateTime Dates)
        {

            ArrayList arrayList3 = new ArrayList();
            arrayList3.Add(Dates);

            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Montly_BalnceSheet_Reports " + Dates + " - Method Executed.");
            DataSet ds3 = FS_Helper.INSERTRECORDS("Sp_Montly_DateWiseReports", arrayList3);
            List<MonthlyReport> BSE = new List<MonthlyReport>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                MonthlyReport BS = new MonthlyReport();
                BS.CreditAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["CreditAmt"].ToString());
                BS.DebitAmt = Convert.ToDecimal(ds3.Tables[0].Rows[i]["DebitAmt"].ToString());
                BS.Diff = Convert.ToDecimal(ds3.Tables[0].Rows[i]["Diff"].ToString());

                BSE.Add(BS);
            }

            return BSE;

        }

        IEnumerable<MonthlyReport> IDataAcessRepository.GetDailyaReport(DateTime Dates)
        {
            throw new NotImplementedException();
        }
    }
}