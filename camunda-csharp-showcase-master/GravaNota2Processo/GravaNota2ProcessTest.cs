using CamundaClient;
using CamundaClient.Service;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CamundaClient.Dto;

namespace GravaNota2Process
{
    [TestFixture]
    class GravaNota2ProcessTest
    {
        [Test]
        public void TestHappyPath()
        {
            // Engine client should point to a dedicated Camunda instance for test, preferrably locally available
            var camunda = new CamundaEngineClient(new System.Uri("http://localhost:8080/engine-rest/engine/default/"), null, null);

            // Deploy the process under test
            string deploymentId = camunda.RepositoryService.Deploy("testcase", new List<object> {
                FileParameter.FromManifestResource(Assembly.GetExecutingAssembly(), "GravaNota2Process.entrega-de-trabalho.bpmn") });

           // string processInstanceId = camunda.BpmnWorkflowService.StartProcessInstance("calculate", new Dictionary<string, object>()
           // {
           //     {"x", 5 },
           //     {"y", 10 }
           // });

            //var externalTasks = camunda.ExternalTaskService.FetchAndLockTasks("testcase", 100, "gravanota", 1000, new List<string>() { "x", "y" });
            //Assert.AreEqual(1, externalTasks.Count);
            //Assert.AreEqual("ServiceTaskCalculate", externalTasks.First().ActivityId);

         //   camunda.ExternalTaskService.Complete("testcase", externalTasks.First().Id, new Dictionary<string, object>() { { "result", 15 } });

         //   var tasks = camunda.HumanTaskService.LoadTasks(new Dictionary<string, string>() {
         //       { "processInstanceId", processInstanceId }
         //   });
         //   Assert.AreEqual(1, tasks.Count);
         //   Assert.AreEqual("UserTaskReviewResult", tasks.First().TaskDefinitionKey);

         //   camunda.HumanTaskService.Complete(tasks.First().Id, new Dictionary<string, object>());

            // not the process instance has ended, TODO: Check state with History

            // cleanup after test case
            camunda.RepositoryService.DeleteDeployment(deploymentId);
        }
    }
}
