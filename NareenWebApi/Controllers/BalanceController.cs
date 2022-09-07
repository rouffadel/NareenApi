//using NareenWebApi.DataAcess;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using NareenWebApi.DataAcess;
using NareenWebApi.Dtos;

namespace NareenWebApi.Controllers
{
    [RoutePrefix("Api/Balance")]
    public class BalanceController : ApiController
    {
        private DataAcessRepository _dataAcessRepository;
        public BalanceController()
        {
            _dataAcessRepository = new DataAcessRepository();
        }

        //// GET: Balance
        //public ActionResult Index()
        //{
        //    return View();
        //} 
        [Route("GetToken")]
        [HttpPost]
        public ResponseVM GetToken(string UserName, string Password)
        {
            try
            {
                return new ResponseVM { Status = "Success", Message = TokenManager.GenerateToken(UserName) };
            }
            catch (Exception)
            {
                throw;
            }

        }

        [Route("GetYearlySummary")]
        [HttpGet]
        public IHttpActionResult GetYearlySummary(int year)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetYearlySummary(year);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetMonthlyDetials")]
        [HttpGet]
        public IHttpActionResult GetMonthlyDetials(int MonthID, int year)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetMonthlyDetials(MonthID, year);
                return Ok(employeeDto);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }

        }
        [Route("GetDailySummary")]
        [HttpGet]
        public IHttpActionResult GetDailySummary(DateTime Dates)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetDailySummary(Dates);
                return Ok(employeeDto);
            }
            catch (Exception)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetBookingYearlySummary")]
        [HttpGet]
        public IHttpActionResult GetBookingYearlySummary(int year)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetBookingYearlySummary(year);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetBookingMonthlyDetials")]
        [HttpGet]
        public IHttpActionResult GetBookingMonthlyDetials(int MonthID, int year)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetBookingMonthlyDetails(MonthID, year);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetHallWiseCountByDate")]
        [HttpGet]
        public IHttpActionResult GetHallWiseCountByDate()
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetHallWiseCountByDate();
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }


        [Route("GetHallWiseCountByHallId")]
        [HttpGet]
        public IHttpActionResult GetHallWiseCountByHallId(int HallId)
        {
            try
            {
                var employeeDto = _dataAcessRepository.GetHallWiseCountByHallId(HallId);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("SaveDevice")]
        [HttpPost]
        public IHttpActionResult SaveDevice(SaveDevice model)
        {
            try
            {
                var employeeDto = _dataAcessRepository.SaveDevice(model);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }
        [Route("GetHallPayment")]
        [HttpGet]
        public IHttpActionResult GetHallPayment()
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetHallPayment();
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetHallPaymentYearly")]
        [HttpGet]
        public IHttpActionResult GetHallPaymentYearly(int year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetHallPaymentYearWise(year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetHallPaymentMonthly")]
        [HttpGet]
        public IHttpActionResult GetHallPaymentMonthly(int MonthId,int year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetHallPaymentMonthWise(MonthId, year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetHallPaymentDetails")]
        [HttpGet]
        public IHttpActionResult GetHallPaymentDetails(int HallId, int MonthId, int year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetHallPaymentdtls(HallId, MonthId, year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetRoyalityPaymentYearly")]
        [HttpGet]
        public IHttpActionResult GetRoyalityPaymentYearly(int year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetRoyalityPaymentYearWise(year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetRoyalityPaymentMonthly")]
        [HttpGet]
        public IHttpActionResult GetRoyalityPaymentMonthly(int MonthId, int year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetRoyalityPaymentMonthWise(MonthId, year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }

        [Route("GetRoyalityPaymentDetails")]
        [HttpGet]
        public IHttpActionResult GetRoyalityPaymentDetails(int HallId,int MonthId, int Year)
        {
            try
            {
                var PaymentYearly = _dataAcessRepository.GetRoyalityPaymentdtls(HallId, MonthId, Year);
                return Ok(PaymentYearly);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }


        [Route("GetHallAmountAndRoyalities")]
        [HttpGet]
        public IHttpActionResult GetHallAmountAndRoyalities()
        {
            try
            {
                var result  = _dataAcessRepository.GetHallPaymentYearWise(DateTime.Now.Year);
                var payments = (List<HallPaymentYearly>)result;
                

                long hallamtCollected = 0;
                long hallBalance = 0;
                long royaltypayment = 0;
                foreach (var item in payments)
                {
                   hallamtCollected += Int64.Parse(item.Collected);
                   hallBalance += Int64.Parse(item.Balance);  
                }
                var royalties = (List<RoyalityPaymentYearly>)_dataAcessRepository.GetRoyalityPaymentYearWise(DateTime.Now.Year);
                foreach (var royalty in royalties)
                {
                    royaltypayment += Int64.Parse(royalty.Amount_Received);
                     
                }
                HallRotalityPayment hallRotalityPayment = new HallRotalityPayment();
                hallRotalityPayment.AllRoyalitiesReceived = royaltypayment.ToString();
                hallRotalityPayment.HallAmountReceived = hallamtCollected.ToString();
                hallRotalityPayment.HallBalanceAmount = hallBalance.ToString();
                return Ok(hallRotalityPayment);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
            }

        }
    }
}