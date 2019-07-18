using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Filters
{
    public class FeatureAuthFilter : Attribute, IAuthorizationFilter
    {
        public string FeatureName { get; set; }

        private Dictionary<string, bool> FeatureStatus = new Dictionary<string, bool>()
        {
            { "Loan", false },
            { "Insurance", false },
            { "Resources", false }
        };
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!FeatureStatus[FeatureName])
            {
                context.Result = new RedirectToRouteResult("Index", "Home", null);
            }
        }
    }
}
