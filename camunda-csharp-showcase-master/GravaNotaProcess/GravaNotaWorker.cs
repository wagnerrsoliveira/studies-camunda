﻿using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace GravaNotaProcess
{
    [ExternalTaskTopic("gravanota")]
    [ExternalTaskVariableRequirements("nota", "material")]
    class GravaNotaAdapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            long bonus = 1;
            long nota = Convert.ToInt64(externalTask.Variables["nota"].Value);
            string materia = Convert.ToString(externalTask.Variables["materia"].Value);
            long notacombonus = nota + bonus;
            resultVariables.Add("nota", notacombonus);
        }

    }
}
