using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Submission(List<Submission> submissions)
        {
            return View();
        }
    }
}
