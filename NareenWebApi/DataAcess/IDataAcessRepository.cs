using NareenWebApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NareenWebApi.DataAcess
{
    //public class IDataAcessRepository
    //{
    //}
    internal interface IDataAcessRepository
    {

        IEnumerable<YearlySummarry> GetYearlySummary(int year);
        IEnumerable<BalanceSheet> GetMonthlyDetials(int MonthID, int year);
        IEnumerable<BalanceSheet> GetDailySummary(DateTime Dates);
        IEnumerable<MonthlyReport> GetDailyaReport(DateTime Dates);

        IEnumerable<BookingYearlySummarry> GetBookingYearlySummary(int year);

        IEnumerable<BookingMonthlySheet> GetBookingMonthlyDetails(int MonthID, int year);

    }
}