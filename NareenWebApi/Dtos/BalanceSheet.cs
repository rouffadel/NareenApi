using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NareenWebApi.Dtos
{
    public class SaveDevice
    {
        public string DeviceId { get; set; }
    }


    public class AmountMaster
    {
        private string _creditAmt = string.Empty;
        public string CreditAmt
        {
            get
            {
                if (string.IsNullOrEmpty(_creditAmt))
                {
                    _creditAmt = "0";

                }
                return Convert.ToDouble(_creditAmt).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _creditAmt = value;
            }
        }


        private string _debitAmt = string.Empty;
        public string DebitAmt
        {
            get
            {
                if (string.IsNullOrEmpty(_debitAmt))
                {
                    _debitAmt = "0";

                }
                return Convert.ToDouble(_debitAmt).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _debitAmt = value;
            }
        }

        private string _diffAmount = string.Empty;
        public string Diff
        {
            get
            {
                if (string.IsNullOrEmpty(_diffAmount))
                {
                    _diffAmount = "0";

                }
                return Convert.ToDouble(_diffAmount).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _diffAmount = value;
            }
        }
    }
    public class BalanceSheet : AmountMaster
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public String Type { get; set; }
        
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
    public class YearlySummarry : AmountMaster
    {
        public string MonthName { get; set; }
        public string MonthNumber { get; set; }

        
    }
    public class BookingYearlySummarry
    {
        public string MonthName { get; set; }
        public string MonthNumber { get; set; }
        public int NoOfBookings { get; set; }
    }
    public class MonthlyReport : AmountMaster
    {

        
    }
    public class HallPayment
    {
        private string _totalAmount = string.Empty;
        public string TotalAmount
        {
            get
            {
                if (string.IsNullOrEmpty(_totalAmount))
                {
                    _totalAmount = "0";

                }
                return Convert.ToDouble(_totalAmount).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _totalAmount = value;
            }
        }

        private string _collected = string.Empty;
        public string Collected
        {
            get
            {
                if (string.IsNullOrEmpty(_collected))
                {
                    _collected = "0";

                }
                return Convert.ToDouble(_collected).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _collected = value;
            }
        }

        private string _balance = string.Empty;
        public string Balance
        {
            get
            {
                if (string.IsNullOrEmpty(_balance))
                {
                    _balance = "0";

                }
                return Convert.ToDouble(_balance).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _balance = value;
            }
        }
    }
    public class HallPaymentYearly : HallPayment
    {
        public string MonthName { get; set; }
        
    }
    public class HallPaymentMonthly : HallPayment
    {
        public string HallName { get; set; }
        public int HallId { get; set; }
        

       
    }
    public class HallPaymentdetails
    {
        private string _amountreceived = string.Empty;
        private string _balance = string.Empty;

        public DateTime PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public string AmountPaid {
            get
            {
                if (string.IsNullOrEmpty(_amountreceived))
                {
                    _amountreceived = "0";

                }
                return Convert.ToDouble(_amountreceived).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _amountreceived = value;
            }
        }
        public string Balance {
            get
            {
                if (string.IsNullOrEmpty(_balance))
                {
                    _balance = "0";

                }
                return Convert.ToDouble(_balance).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _balance = value;
            }
        }
    }
    public class RoyalityPaymentYearly
    {
        public string MonthName { get; set; }
        private string _amountReceived = string.Empty;
        public string Amount_Received
        {
            get
            {
                if (string.IsNullOrEmpty(_amountReceived))
                {
                    _amountReceived = "0";

                }
                return Convert.ToDouble(_amountReceived).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _amountReceived = value;
            }
        }
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
        private string _amountReceived = string.Empty;
        public string Amount_Received
        {
            get
            {
                if (string.IsNullOrEmpty(_amountReceived))
                {
                    _amountReceived = "0";

                }
                return Convert.ToDouble(_amountReceived).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _amountReceived = value;
            }
        }
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

        private string _amountReceived = string.Empty;
        public string Amount_Received {
            get
            {
                if (string.IsNullOrEmpty(_amountReceived))
                {
                    _amountReceived = "0";

                }
                return Convert.ToDouble(_amountReceived).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _amountReceived = value;
            }
        }
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
        private string _hallamountreceived = string.Empty;
        private string _hallbalance = string.Empty;
        private string _hallroyalties= string.Empty;
        public string HallAmountReceived { get { 
                if(string.IsNullOrEmpty(_hallamountreceived))
                {
                    _hallamountreceived = "0";

                }
                return Convert.ToDouble(_hallamountreceived).ToString("N", new CultureInfo("hi-IN"));

            } set {
                _hallamountreceived = value;
            }
        }
        public string HallBalanceAmount {
            get
            {
                if (string.IsNullOrEmpty(_hallbalance))
                {
                    _hallbalance = "0";

                }
                return Convert.ToDouble(_hallbalance).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _hallbalance = value;
            }
        }
        public string AllRoyalitiesReceived {
            get
            {
                if (string.IsNullOrEmpty(_hallroyalties))
                {
                    _hallroyalties = "0";

                }
                return Convert.ToDouble(_hallroyalties).ToString("N", new CultureInfo("hi-IN"));

            }
            set
            {
                _hallroyalties = value;
            }
        }
        //public string Balance { get; set; }
    }
}