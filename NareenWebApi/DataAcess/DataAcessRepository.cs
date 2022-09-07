using Fadel.EmailComponent;
using NareenWebApi.Dtos;
using Newtonsoft.Json;
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
        public object GetHallPayment()
        {

            ArrayList arrayList = new ArrayList();
            //arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Yearly_HallPayments "+" - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_GetHallPayements", arrayList.ToArray());
            List<HallPayment> HallPay = new List<HallPayment>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                HallPayment HP = new HallPayment();
                HP.TotalAmount = ds3.Tables[0].Rows[i]["totalamount"].ToString();
                HP.Collected = ds3.Tables[0].Rows[i]["collected"].ToString();
                HP.Balance = ds3.Tables[0].Rows[i]["balance"].ToString();
                //BS.NoOfBookings = Convert.ToInt32(ds3.Tables[0].Rows[i]["bookings"]);
                HallPay.Add(HP);
            }

            return HallPay;

        }

        public object GetHallPaymentYearWise(int year)
        {

            ArrayList arrayList = new ArrayList();
            arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Yearly_HallPayments " + year + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_Yearly_HallPayments", arrayList.ToArray());
            List<HallPaymentYearly> HallPayY = new List<HallPaymentYearly>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                HallPaymentYearly HPY = new HallPaymentYearly();
                HPY.MonthName   = ds3.Tables[0].Rows[i]["monthname"].ToString();
                HPY.TotalAmount = ds3.Tables[0].Rows[i]["totalamount"].ToString();
                HPY.Collected   = ds3.Tables[0].Rows[i]["collected"].ToString();
                HPY.Balance     = ds3.Tables[0].Rows[i]["balance"].ToString();
                //BS.NoOfBookings = Convert.ToInt32(ds3.Tables[0].Rows[i]["bookings"]);
                HallPayY.Add(HPY);
            }

            return HallPayY;

        }

        public object GetHallPaymentMonthWise(int MonthId,int year)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(MonthId);
            arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Monthly_HallPayments " + MonthId + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_Monthly_HallPayments", arrayList.ToArray());
            List<HallPaymentMonthly> HallPayM = new List<HallPaymentMonthly>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                HallPaymentMonthly HPM = new HallPaymentMonthly();
                HPM.HallName    = ds3.Tables[0].Rows[i]["HallName"].ToString();
                HPM.HallId      = Convert.ToInt32(ds3.Tables[0].Rows[i]["HallId"].ToString());
                HPM.TotalAmount = ds3.Tables[0].Rows[i]["totalamount"].ToString();
                HPM.Collected   = ds3.Tables[0].Rows[i]["collected"].ToString();
                HPM.Balance     = ds3.Tables[0].Rows[i]["balance"].ToString();
                HallPayM.Add(HPM);
            }

            return HallPayM;

        }

        public object GetHallPaymentdtls(int HallId, int MonthId, int year)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(HallId);
            arrayList.Add(MonthId);
            arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Monthly_HallPaymentDetails " + HallId + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_Monthly_HallPaymentDetailsNew", arrayList.ToArray());
            List<HallPaymentdetails> HallPayD = new List<HallPaymentdetails>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                HallPaymentdetails HPD = new HallPaymentdetails();
                HPD.PaymentDate  = Convert.ToDateTime(ds3.Tables[0].Rows[i]["PaymentDate"]);
                HPD.CustomerName = ds3.Tables[0].Rows[i]["CustomerName"].ToString();
                HPD.AmountPaid   = ds3.Tables[0].Rows[i]["collected"].ToString();
                HPD.Balance      = ds3.Tables[0].Rows[i]["balance"].ToString();
                HallPayD.Add(HPD);
            }
            return HallPayD;
        }

        public object GetRoyalityPaymentYearWise(int year)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -sp_Yearly_Royality " + year + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "sp_Yearly_Royality", arrayList.ToArray());
            List<RoyalityPaymentYearly> RoyalityPayY = new List<RoyalityPaymentYearly>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                RoyalityPaymentYearly RPY = new RoyalityPaymentYearly();
                RPY.MonthName = ds3.Tables[0].Rows[i]["monthname"].ToString();
                RPY.Amount_Received = ds3.Tables[0].Rows[i]["Total"].ToString();
                RPY.Decoration = ds3.Tables[0].Rows[i]["Decoration"].ToString();
                RPY.CookingWater = ds3.Tables[0].Rows[i]["Cooking Water"].ToString();
                RPY.LandScape = ds3.Tables[0].Rows[i]["LandScape"].ToString();
                RPY.Power = ds3.Tables[0].Rows[i]["Power"].ToString();
                RPY.LED = ds3.Tables[0].Rows[i]["LED"].ToString();
                RPY.Shehnai = ds3.Tables[0].Rows[i]["Shehnai"].ToString();
                RPY.Rooms = ds3.Tables[0].Rows[i]["Rooms"].ToString();
                RPY.Sofa = ds3.Tables[0].Rows[i]["Sofa"].ToString();
                RPY.Others = ds3.Tables[0].Rows[i]["Others"].ToString();
                RoyalityPayY.Add(RPY);
            }
            return RoyalityPayY;

        }
        public object GetRoyalityPaymentMonthWise(int MonthId, int year)
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(MonthId);
            arrayList.Add(year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -sp_Monthly_Royality " + year + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "sp_Monthly_Royality", arrayList.ToArray());
            List<RoyalityPaymentMonthly> RoyalityPayM = new List<RoyalityPaymentMonthly>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                RoyalityPaymentMonthly RPM = new RoyalityPaymentMonthly();
                RPM.HallName = ds3.Tables[0].Rows[i]["HallName"].ToString();
                RPM.HallId = Convert.ToInt32(ds3.Tables[0].Rows[i]["Hallid"].ToString());
                RPM.Amount_Received = ds3.Tables[0].Rows[i]["Total"].ToString();
                RPM.Decoration = ds3.Tables[0].Rows[i]["Decoration"].ToString();
                RPM.CookingWater = ds3.Tables[0].Rows[i]["Cooking Water"].ToString();
                RPM.LandScape = ds3.Tables[0].Rows[i]["LandScape"].ToString();
                RPM.Power = ds3.Tables[0].Rows[i]["Power"].ToString();
                RPM.LED = ds3.Tables[0].Rows[i]["LED"].ToString();
                RPM.Shehnai = ds3.Tables[0].Rows[i]["Shehnai"].ToString();
                RPM.Rooms = ds3.Tables[0].Rows[i]["Rooms"].ToString();
                RPM.Sofa = ds3.Tables[0].Rows[i]["Sofa"].ToString();
                RPM.Others = ds3.Tables[0].Rows[i]["Others"].ToString();
                RoyalityPayM.Add(RPM);
            }
            return RoyalityPayM;
        }
        public object GetRoyalityPaymentdtls(int HallId,int MonthId, int Year)
        {

            ArrayList arrayList = new ArrayList();
            arrayList.Add(HallId);
            arrayList.Add(MonthId);
            arrayList.Add(Year);
            clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -sp_RoyalityDetails " + HallId + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "sp_RoyalityDetailsNew", arrayList.ToArray());
            List<RoyalityPaymentdetails> RoyalityPayD = new List<RoyalityPaymentdetails>();
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                RoyalityPaymentdetails RPD = new RoyalityPaymentdetails();
                RPD.PaymentDate = Convert.ToDateTime(ds3.Tables[0].Rows[i]["PaymentDate"]);
                RPD.Amount_Received = ds3.Tables[0].Rows[i]["Total"].ToString();
                RPD.Decoration = ds3.Tables[0].Rows[i]["Decoration"].ToString();
                RPD.CookingWater = ds3.Tables[0].Rows[i]["Cooking Water"].ToString();
                RPD.LandScape = ds3.Tables[0].Rows[i]["LandScape"].ToString();
                RPD.Power = ds3.Tables[0].Rows[i]["Power"].ToString();
                RPD.LED = ds3.Tables[0].Rows[i]["LED"].ToString();
                RPD.Shehnai = ds3.Tables[0].Rows[i]["Shehnai"].ToString();
                RPD.Rooms = ds3.Tables[0].Rows[i]["Rooms"].ToString();
                RPD.Sofa = ds3.Tables[0].Rows[i]["Sofa"].ToString();
                RPD.Others = ds3.Tables[0].Rows[i]["Others"].ToString();
                RoyalityPayD.Add(RPD);
            }

            return RoyalityPayD;

        }

        public object GetHallAmountAndRoyalities()
        {
            ArrayList arrayList = new ArrayList();
            //arrayList.Add(year);
            //clsLog.WriteInfoLog("{Info} " + DateTime.Now + " - FS_Helper.INSERTRECORDS - SPNAME -Sp_Yearly_HallPayments " + " - Method Executed.");
            DataSet ds3 = SqlHelper.ExecuteDataset(StrConnection, "Sp_GetHallPayements", arrayList.ToArray());
            //HallRotalityPayment HallroyalPay = new HallRotalityPayment();
            //for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            //{
                HallRotalityPayment HRP = new HallRotalityPayment();
                HRP.HallAmountReceived = "2500";
                HRP.HallBalanceAmount = "5200";
                HRP.AllRoyalitiesReceived = "1000";
                //HRP.HallAmountReceived = ds3.Tables[0].Rows[i]["totalamount"].ToString();
                //HRP.HallBalanceAmount = ds3.Tables[0].Rows[i]["collected"].ToString();
                //HRP.AllRoyalitiesReceived = ds3.Tables[0].Rows[i]["balance"].ToString();
                //HallroyalPay.Add(HRP);
            //}

            return HRP;

        }

    }
}