using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : IAuthorizationFilter
    {
        public FeatureAuthFilter(IFeatureService featureService, string featureName)
        {
            this.featureService = featureService;
            this.featureName = featureName;
        }

        private readonly IFeatureService featureService;
        private readonly string featureName;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!featureService.IsFeatureActive(featureName))
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
