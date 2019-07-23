using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using System.Text;
using System.IO;
using Globomantics.ActionResults;

namespace Globomantics.Controllers
{
    public class DocumentController : Controller
    {
        private IRateService rateService;

        public DocumentController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCDRates()
        {
            var cdRates = rateService.GetCDRates();
            return new CsvResult(cdRates, "CDRates.csv");
        }

        public IActionResult GetMortgageRates()
        {
            var cdRates = rateService.GetCDRates();
            return new CsvResult(cdRates, "MortgageRates.csv");            
        }

        public IActionResult GetCreditCardRates()
        {
            var cdRates = rateService.GetCreditCardRates();            
            return new CsvResult(cdRates, "CreditCardRates.csv");            
        }
        
    }
}
