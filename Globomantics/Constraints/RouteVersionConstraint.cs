﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globomantics.Constraints
{
    public class RouteVersionConstraint : IRouteConstraint
    {
        private double requiredVersion;

        public RouteVersionConstraint(double version)
        {
            this.requiredVersion = version;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            double requestedVersion;
            string urlVersion = values["version"].ToString()?.Substring(1);

            if (double.TryParse(urlVersion, out requestedVersion))
            {
                return requestedVersion >= requiredVersion && requestedVersion < requiredVersion + 1;
            }

            return false;
        }
    }
}
