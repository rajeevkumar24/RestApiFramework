//using System;
//using APITests.Test;
//using AventStack.ExtentReports;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RestApiDemo;


//namespace APITests
//{
//    [TestClass]
//    public class Test1 : BaseTest
//    {
        
//        [TestMethod]
//        public void VerifyAPIResponse()
//        {
//            var demo = new Users<UserDTOResponse>();
//            var user = demo.GetUsers(baseUrl,"api/users?page=2");
//            Assert.AreEqual(2, user.page);
//            Reporter.LogReport(Status.Info, "entering value");
//            Assert.AreEqual("Michael", user.data[0].first_name);

//        }
      
//        [TestMethod]
//        public void VerifyAddingNewUser()
//        {
            
//            /**
          
//            string payload = @"{
//                                ""name"": ""morpheus"",
//                                    ""job\"": ""leader"" 
//                                   }";
//          * 
//          */
//            //string payload = "{" +
//            //                    "\"name\": \"Mikel\"," +
//            //                        "\"job\": \"Team Leader\"" +
//            //                       "}";
//            var demo = new Demo<CreateUserDTO>();
//            var user = demo.CreateUsers("api/users", demo);
//            //= demo.CreateUsers("api/users", payload);

//            Assert.AreEqual("Mikel", user.name);
//            Reporter.LogReport(Status.Pass, "The value is correct");
//            Assert.AreEqual("Team Leader", user.job);
//        }

        
//        [TestMethod]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
//            @"|DataDirectory|\TestData\TestCase.csv", "TestCase#csv",
//            DataAccessMethod.Sequential)]
//        public void VerifyAddingNewUser1()
//        {
                    
//            var users = new CreateUserDTORequest();
//            users.name = TestContext.DataRow["name"].ToString();
//            users.job = TestContext.DataRow["job"].ToString();
//            Reporter.LogReport(Status.Info, "Test Data:" +users.name);
//            Reporter.LogReport(Status.Info, "Test Data:" + users.job);
            
//            var demo = new Demo<CreateUserDTO>();
//            var user = demo.CreateUsers("api/users", users);

//            //Assert.AreEqual("Mike", user.name);
//            //Reporter.LogReport(Status.Pass, "The value is correct");
//            //Assert.AreEqual("Team Lead", user.job);

            
//            var demoOne = new Demo<ListOfObjectsDTO>();
//            var userOne = demoOne.GetUsers("api/users?page=2");
//            Assert.AreEqual(2, user.page);
//            Reporter.LogReport(Status.Info, "entering value");
//            Assert.AreEqual("Mike", user.data[0].first_name);
//           // Assert.AreEqual("TestUser", user.data[0].first_name);
//        }
//        [DeploymentItem("TestData\\CreateUser.json")]
//        [TestMethod]
//        public void VerifyAddingNewUserJson()
//        {

//            var payload = new APIHelper();
//            var dempo = payload.parseJson<CreateUserDTORequest>("CreateUser.json");

//            var demo = new Demo<CreateUserDTO>();
//            var user = demo.CreateUsers("api/users", payload);

//            //Assert.AreEqual("Mike", user.name);
//            //Reporter.LogReport(Status.Pass, "The value is correct");
//            //Assert.AreEqual("Team Lead", user.job);


//            var demoOne = new Demo<ListOfObjectsDTO>();
//            var userOne = demoOne.GetUsers("api/users?page=2");
//            Assert.AreEqual(2, user.page);
//            Reporter.LogReport(Status.Info, "entering value");
//            Assert.AreEqual("Mike", user.data[0].first_name);
//            // Assert.AreEqual("TestUser", user.data[0].first_name);
//        }
//    }
//}
