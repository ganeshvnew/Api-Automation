using System;
using NUnit.Framework;
using APIAutomation.ExtentReportManager;
using APIAutomation.RestSharpBase;

namespace ApiAutomation.Test
{
    [TestFixture]
    class BaseTest : ReportListener
    {
        protected String baseUrl = Constants.BASE_URL;
    }
}