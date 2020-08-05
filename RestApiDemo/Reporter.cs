using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestApiDemo
{
    public static class Reporter
    {
        //public static ExtentReports extentReports;

        public static ExtentHtmlReporter htmlReporter;

        public static ExtentTest extentTest;

        public static ExtentReports extentReports;
        
        /// <summary>
        /// This method is used for creating the extent report
        /// </summary>
        public static void CreateExtentReport(string reportName,string documentTitle,dynamic path)
        {
            htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.DocumentTitle = documentTitle;
            htmlReporter.Config.ReportName = reportName;
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
     
        }

        public static void CreateTest(string TestName)
        {
            extentTest = extentReports.CreateTest(TestName);
        }
        public static void LogReport(Status status,string message)
        {
            extentTest.Log(status,message);
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                extentTest.Pass("Test is pass");
            }
            else
            {
                extentTest.Fail("Test is fail");
            }
        }

     
    }
}
