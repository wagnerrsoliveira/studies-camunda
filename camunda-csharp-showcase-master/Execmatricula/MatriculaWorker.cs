using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace Execmatricula
{
    [ExternalTaskTopic("matricula")]
    // [ExternalTaskVariableRequirements("x", "y")]
    class MatriculaAdapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            // complementar buscando do database

            long matricula = 1001;
            resultVariables.Add("matricula", matricula);
        }

    }
}
