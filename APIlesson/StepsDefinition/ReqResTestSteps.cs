using APIlesson.Hooks;
using APIlesson.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Newtonsoft.Json;
using System.IO;

namespace APIlesson.StepsDefinition
{
    [Binding]
    class ReqResTestSteps
    {
        Context context;

        public ReqResTestSteps(Context _context)
        {
            context = _context;
        }

        [BeforeScenario]
        public void SetUp()
        {
            //Clear the table  (for all tasks)    
            
        }       


        [Given(@"that ReqRes service is invoked with GET endpoint (.*)")]
        public void GivenThatReqResServiceIsInvokedWithGETEndpointApiUsersPage(string resource)
        {
            //Populate the database table (for GET and Delete tasks)
            context.GetMethod(resource);
        }

        [Then(@"the statuscode for GET is equal to (.*)")]
        public void ThenTheStatuscodeForGETIsEqualToOK(string code)
        {
            Assert.IsTrue(context.resultStatusCode.Equals(code));
        }

        [Then(@"the response description for GET is equal to (.*)")]
        public void ThenTheResponseDescriptionForGETIsEqualToOK(string description)
        {
            Assert.IsTrue(context.resultDescription.Equals(description));
        }

        [Then(@"the list of users are returned as below:")]
        public void ThenTheListOfUsersAreReturnedAsBelow(Table table)
        {
            var expectedtableData = table.CreateSet<Data>();
            string endPointContent = context.resultContent;
            var actualResultContent = JsonConvert.DeserializeObject<ResultPage>(endPointContent).data;
            Assert.IsTrue(CompareTwoLists(expectedtableData, actualResultContent));
            //Assert.IsTrue(expectedtableData.Equals(actualResultContent));            
        }

        public bool CompareTwoLists(object firstList, object secondList)
        {
            var firstObject = JsonConvert.SerializeObject(firstList);
            var secondObject = JsonConvert.SerializeObject(secondList);
            return firstObject == secondObject;

        }

        [Given(@"that ReqRes service is invoked with POST endpoint (.*)")]
        public void GivenThatReqResServiceIsInvokedWithPOSTEndpointApiUsers(string resource)
        {
            context.PostMethod(resource, File.ReadAllText(@"PostaUser.json"));
        }

        [Then(@"the status code for Post is equal to (.*)")]
        public void ThenTheStatusCodeForPostIsEqualToCompleted(string code)
        {
            Assert.IsTrue(context.resultStatusCode.Equals(code));
        }

        [Then(@"the response description for Post is equal to (.*)")]
        public void ThenTheResponseStatusForPostIsEqualToCreated(string responseStatus)
        {
            Assert.IsTrue(context.resultDescription.Equals(responseStatus));
        }

        [Given(@"that ReqRes service is invoked with PUT endpoint (.*)")]
        public void GivenThatReqResServiceIsInvokedWithPUTEndpointApiUsers(string resource)
        {
            Dictionary<string, string> dataToModify = new Dictionary<string, string>();
            dataToModify.Add("name", "morpheus");
            dataToModify.Add("job", "servant");

            context.PutMethod(resource, dataToModify);
        }

        [Then(@"the status code for Put is equal to (.*)")]
        public void ThenTheStatusCodeForPutIsEqualToCompleted(string code)
        {
            Assert.IsTrue(context.resultStatusCode.Equals(code));
        }

        [Then(@"the response description for Put is equal to (.*)")]
        public void ThenTheResponseStatusForPutIsEqualToOK(string responseStatus)
        {
            Assert.IsTrue(context.resultDescription.Equals(responseStatus));
        }

        [Given(@"that ReqRes service is invoked with DELETE endpoint (.*)")]
        public void GivenThatReqResServiceIsInvokedWithDELETEEndpointApiUsers(string resource)
        {
            //Populate the database table (for GET and Delete tasks)
            context.DeleteMethod(resource);
        }

        [Then(@"the statuscode for DELETE is equal to (.*)")]
        public void ThenTheStatuscodeForDELETEIsEqualToNoContent(string statusCode)
        {
            Assert.IsTrue(context.resultStatusCode.Equals(statusCode));
        }

        [Then(@"the response description for DELETE is equal to (.*)")]
        public void ThenTheResponseStatusForDELETEIsEqualToOK(string responseStatus)
        {
            Assert.IsTrue(context.resultDescription.Equals(responseStatus));
        }
    }
}
