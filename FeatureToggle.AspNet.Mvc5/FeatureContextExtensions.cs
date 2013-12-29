﻿using System.Web.Mvc;
using System.Web.Routing;

namespace FeatureToggle.AspNet.Mvc5
{
    public static class FeatureContextExtensions
    {
        public static FeatureSetContainer WithRoute(this FeatureSetContainer target, string routeName)
        {
            routeName.CheckNull("routeName");

            var route = new Route(routeName + "/{action}/{param}", new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(new { controller = "FeatureToggleHome", action = "Index", param = UrlParameter.Optional }),
                DataTokens = new RouteValueDictionary()
            };

            route.DataTokens["Namespaces"] = new[] { "FeatureToggle.AspNet.Mvc5" };

            RouteTable.Routes.Insert(0, route);

            return target;
        }
    }
}
