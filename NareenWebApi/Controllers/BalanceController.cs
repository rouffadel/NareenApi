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
    }
}