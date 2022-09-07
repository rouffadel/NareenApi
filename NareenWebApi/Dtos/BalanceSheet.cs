using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareenWebApi.Dtos
{
    public class SaveDevice
    {
        public string DeviceId { get; set; }
    }
    public class BalanceSheet
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        public decimal CreditAmt { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal Diff { get; set; }
    }
    public class HallWiseCount
    {
        public int TotalCount { get; set; }
        public string HallName { get; set; }
        public int HallId { get; set; }
    }
    public class BookingMonthlySheet
    {
        public string HallName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookingId { get; set; }
        public int HallId { get; set; }
        public string FunctionTitle { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMobileNo { get; set; }
        public DateTime FunctionDate { get; set; }
        public int TimeValue { get; set; }
        public string TimeName { get; set; }
        public string Description { get; set; }
        public string CustomerAddress { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountByAdmin { get; set; }
        public decimal Amount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal GST { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal Balance { get; set; }
        public string AdminRemark { get; set; }
        public bool IsCatering { get; set; }
        public int Guestcount { get; set; }
        public int Costperplate { get; set; }
        public decimal CateringAmount { get; set; }
        public decimal CateringTaxAmount { get; set; }
        public decimal CateringGST { get; set; }
        public decimal CateringFinalAmt { get; set; }
        public string CateringUploadMenu { get; set; }
        public decimal AdditionalAmount { get; set; }
        public string Muhurtham { get; set; }
    }
    public class YearlySummarry
    {
        public string MonthName { get; set; }
        public string MonthNumber { get; set; }
        public decimal CreditAmt { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal Diff { get; set; }
    }
    public class BookingYearlySummarry
    {
        public string MonthName { get; set; }
        public string MonthNumber { get; set; }
        public int NoOfBookings { get; set; }
    }
    public class MonthlyReport
    {

        public decimal CreditAmt { get; set; }
        public decimal DebitAmt { get; set; }
        public decimal Diff { get; set; }
    }
    public class HallPayment
    {
        public string TotalAmount { get; set; }
        public string Collected { get; set; }
        public string Balance { get; set; }
    }
    public class HallPaymentYearly
    {
        public string MonthName { get; set; }
        public string TotalAmount { get; set; }
        public string Collected { get; set; }
        public string Balance { get; set; }
    }
    public class HallPaymentMonthly
    {
        public string HallName { get; set; }
        public int HallId { get; set; }
        public string TotalAmount { get; set; }
        public string Collected { get; set; }
        public string Balance { get; set; }
    }
    public class HallPaymentdetails
    {
        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public string AmountPaid { get; set; }
        public string Balance { get; set; }
    }
    public class RoyalityPaymentYearly
    {
        public string MonthName { get; set; }
        public string Amount_Received { get; set; }
        public string Decoration { get; set; }
        public string CookingWater { get; set; }
        public string LandScape { get; set; }
        public string Power { get; set; }
        public string LED { get; set; }
        public string Shehnai { get; set; }
        public string Rooms { get; set; }
        public string Sofa { get; set; }
        public string Others { get; set; }
    }
    public class RoyalityPaymentMonthly
    {
        public int HallId { get; set; }
        public string HallName { get; set; }
        public string Amount_Received { get; set; }
        public string Decoration { get; set; }
        public string CookingWater { get; set; }
        public string LandScape { get; set; }
        public string Power { get; set; }
        public string LED { get; set; }
        public string Shehnai { get; set; }
        public string Rooms { get; set; }
        public string Sofa { get; set; }
        public string Others { get; set; }
    }
    public class RoyalityPaymentdetails
    {
        public DateTime PaymentDate { get; set; }
        public string Amount_Received { get; set; }
        public string Decoration { get; set; }
        public string CookingWater { get; set; }
        public string LandScape { get; set; }
        public string Power { get; set; }
        public string LED { get; set; }
        public string Shehnai { get; set; }
        public string Rooms { get; set; }
        public string Sofa { get; set; }
        public string Others { get; set; }
    }

    public class HallRotalityPayment
    {
        public string HallAmountReceived { get; set; }
        public string HallBalanceAmount { get; set; }
        public string AllRoyalitiesReceived { get; set; }
        //public string Balance { get; set; }
    }
}