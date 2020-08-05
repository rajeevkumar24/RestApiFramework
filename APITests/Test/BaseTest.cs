using Microsoft.VisualStudio.TestTools.UnitTesting;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiDemo;

namespace APITests.Test
{
    [TestClass]
    public class BaseTest
    {
        public string baseUrl = "https://reqres.in/";

        public TestContext TestContext { get; set; }

       
        [TestInitialize]
        public void SetUpTest()
        {
            var dir = TestContext.TestRunDirectory;
            Reporter.CreateExtentReport("API Regression Test", "API Report", dir);
            Reporter.CreateTest(TestContext.TestName);

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            var teststatus = TestContext.CurrentTestOutcome;

            Status logstatus;
            switch (teststatus)
            {
                case UnitTestOutcome.Failed:
                    logstatus = Status.Fail;
                    Reporter.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    logstatus = Status.Pass;
                    Reporter.TestStatus(logstatus.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;

                   
            }
            Reporter.FlushReport();
        }



        //[ClassInitialize]
        //public static void SetUp(TestContext testContext)
        //{
        //    var dir = testContext.TestRunDirectory;
        //    Reporter.CreateExtentReport("API Regression Test", "API Report", dir);

        //}
        //// [ClassCleanup]
        // public static void cleanUp()
        // {
        //     Reporter.FlushReport();
        // }


    }
}
