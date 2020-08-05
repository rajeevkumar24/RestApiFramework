using System;
using APITests.Test;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApiDemo;


namespace APITests
{
    [TestClass]
    public class Test1 : BaseTest
    {
        
        [TestMethod]
        public void VerifyAPIResponse()
        {
            var demo = new Users<UserDTOResponse>();
            var user = demo.GetUsers(baseUrl,"api/users?page=2");
            Assert.AreEqual(2, user.page);
            Reporter.LogReport(Status.Info, "entering value");
            Assert.AreEqual("Michael", user.data[0].first_name);

        }
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @"|DataDirectory|\TestData\TestCase.csv", "TestCase#csv",
            DataAccessMethod.Sequential)]
        public void VerifyAddingNewUserUsingTestDatafile()
        {

            var data = new CreateUserDTORequest();
            data.name = TestContext.DataRow["name"].ToString();
            data.job = TestContext.DataRow["job"].ToString();
            Reporter.LogReport(Status.Info, "Test Data:" + data.name);
            Reporter.LogReport(Status.Info, "Test Data:" + data.job);

            var demo = new Users<CreateUserDTORequest>();
            var user = demo.CreateUsers(baseUrl,"api/users", data);

            Assert.AreEqual(data.name, user.name);
            Reporter.LogReport(Status.Pass, "The value is correct");
            Assert.AreEqual(data.job, user.job);
            
        }
        [DeploymentItem("TestData\\CreateUser.json")]
        [TestMethod]
        public void VerifyAddingNewUserJson()
        {

            var payload = new APIHelper();
            var dempo = payload.parseJson<CreateUserDTORequest>("CreateUser.json");

            var demo = new Users<CreateUserDTORequest>();
            var user = demo.CreateUsers(baseUrl, "api/users", payload);

            Assert.AreEqual("Mike", user.name);
            Reporter.LogReport(Status.Pass, "The value is correct");
            Assert.AreEqual("Team Lead", user.job);
        }           
                
}
}
