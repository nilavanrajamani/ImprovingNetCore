﻿using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Components
{
    public class MortgageRatesViewComponent : ViewComponent
    {
        private readonly IRateService rateService;

        public MortgageRatesViewComponent(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var rates = rateService.GetMortgageRates();
            return View(rates);
        }
    }
}
