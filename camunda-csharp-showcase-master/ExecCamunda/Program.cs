using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using CamundaClient;
using CamundaClient.Dto;
using CamundaClient.Service;


using NUnit.Framework;



namespace ExecCamunda
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\n" + "Iniciando Exemplo camunda CSharp.\n\n");

            // Engine client should point to a dedicated Camunda instance for test, preferrably locally available
            var camunda = new CamundaEngineClient(new System.Uri("http://localhost:8080/engine-rest/engine/default/"), "demo", "demo");

            Console.WriteLine("\n" + "Conectado ao camunda\n");


            // Deploy the process under test
            string deploymentId = camunda.RepositoryService.Deploy("testcase", new List<object> {
                FileParameter.FromManifestResource(Assembly.GetExecutingAssembly(), "ExecCamunda.CamundaModel.samplecsharp.bpmn") });

            Console.WriteLine("\n" + "Deploy realizado com sucesso Deplouyid =" + deploymentId + "\n");
            Console.ReadLine(); // wait for ANY KEY

            // inicia uma instancia do processo samplecsharp
            string processInstanceId = camunda.BpmnWorkflowService.StartProcessInstance("samplecsharp", new Dictionary<string, object>()
            {
                {"notafiscal", 100 },
                {"businesskey", "E10-F10-100"  }
            });

            Console.WriteLine("\n" + "consulte a instancia criada =" + processInstanceId);
            Console.ReadLine(); // wait for ANY KEY

            var tasks = camunda.HumanTaskService.LoadTasks(new Dictionary<string, string>() {
                 { "processInstanceId", processInstanceId }
            });

            Console.WriteLine("\n" + "LoadTask retornou" + tasks.Count + " Tarefas");
            Console.WriteLine("\n" + "A key da tarefa he =" + tasks.First().TaskDefinitionKey);
            Console.WriteLine("\n" + "A assigner da tarefa he =" + tasks.First().Assignee);
            Console.ReadLine(); // wait for ANY KEY

            camunda.HumanTaskService.Complete(tasks.First().Id, new Dictionary<string, object>()
              {
                {"nome", "Marcio Junior Vieira" },
              });

            Console.WriteLine("\n" + "tarefa task1 completa" );
            Console.ReadLine(); // wait for ANY KEY

            var tasks2 = camunda.HumanTaskService.LoadTasks(new Dictionary<string, string>() {
                 { "processInstanceId", processInstanceId }
            });

            Console.WriteLine("\n" + "LoadTask retornou" + tasks2.Count + " Tarefas");
            Console.WriteLine("\n" + "A key da tarefa he =" + tasks2.First().TaskDefinitionKey);
            Console.WriteLine("\n" + "A assigner da tarefa he =" + tasks2.First().Assignee);

            camunda.HumanTaskService.Complete(tasks2.First().Id, new Dictionary<string, object>()
              {
                {"nome", "Marcio Junior" },
              });

            Console.WriteLine("\n" + "tarefa task2 completa");

            Console.ReadLine(); // wait for ANY KEY


        }
    }
}
