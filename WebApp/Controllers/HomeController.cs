using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VotingServices;
using Entities;
using WebApp.Models;
using System.Text;

namespace WebApp.Controllers
{

    public class HomeController : Controller
    {
        
        public HomeController(ILog logger, ICompaniesService companiesService,IVotingService votingService,IUserService userService)
        {
            _logger = logger;
            _votingService = votingService;
            _companyService = companiesService;
            _userService = userService;
            
        }

     
        List<Company> companies = new List<Company>();
        private ILog _logger;
        private ICompaniesService _companyService;
        private IUserService _userService;
        private IVotingService _votingService;

        public ActionResult Index(int page = 1, int companiesOnPage = 10)
        {
            
            int totalCompanies = _companyService.GetCompaniesCount();
            List<Company> companies = _companyService.GetCompaniesList(page,companiesOnPage);
            PageInfo pageInfo = new PageInfo() { PageNumber = page,PageSize = companiesOnPage,TotalItems=totalCompanies};
            ComaniesViewModel companiesViewModel=new ComaniesViewModel() { PageInfo=pageInfo,Companies=companies};

            return View(companiesViewModel);
        }

        public ActionResult Enter(string userName,string password)
        {
            User user = null;
            if (_userService.LogIn(userName, password))
            {
                //HttpContext.Response.Cookies["id"].Value = userModel.UserName;
                user = _userService.GetUserByUserName(userName);
            }

            return View(user);
        }

        public ActionResult CompanyWithVoting(int companyID)
        {
            Company selectedCompany = _companyService.GetCompanyById(companyID);

            return View(selectedCompany);
        }

        public ActionResult Vote(VotingFormModel votingForm)
        {
            User user;
            String userId=null;
            //userId = HttpContext.Response.Cookies["id"].Value;
            
            if (userId!=null)
            {
                user = _userService.GetUserByUserName(HttpContext.Response.Cookies["id"].Value);
                _votingService.Vote();
            }
            else
            {
                _votingService.AnonymousVote();
            }
            

            return View();
        }

        public ActionResult LogOut(User user)
        {
            return View("Enter");
        }

    }
}