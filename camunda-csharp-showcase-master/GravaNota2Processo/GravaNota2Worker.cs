using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;


namespace GravaNota2Process
{
    [ExternalTaskTopic("gravanota")]
    [ExternalTaskVariableRequirements("nota", "materia")]
    class GravaNota2Adapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            long bonus = 1;
            long nota = Convert.ToInt64(externalTask.Variables["nota"].Value);
            string materia = Convert.ToString(externalTask.Variables["materia"].Value);
            long notacombonus = nota + bonus;
            
            //connect database
            //result set where nota


            resultVariables.Add("nota", notacombonus);
        }

    }
}
