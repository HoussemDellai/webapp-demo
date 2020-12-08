using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AppInsightsController : Controller
    {
        private TelemetryClient _telemetry;

        public AppInsightsController(TelemetryClient telemetry)
        {
            _telemetry = telemetry;
        }

        public IActionResult TrackEvent()
        {
            // Call the required Track method.
            _telemetry.TrackEvent("TrackEventPageRequested",
                new Dictionary<string, string>
                {
                    { "Controller Name", nameof(AppInsightsController) },
                    { "User", "DemoUser" },
                });

            return View();
        }

        public IActionResult TrackException()
        {
            try
            {
                var zero = 0;
                int result = 1 / zero;
            }
            catch (Exception ex)
            {
                _telemetry.TrackException(ex,
                    new Dictionary<string, string>
                    {
                        { "Controller Name", nameof(AppInsightsController) },
                        { "User", "DemoUser" },
                    });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
