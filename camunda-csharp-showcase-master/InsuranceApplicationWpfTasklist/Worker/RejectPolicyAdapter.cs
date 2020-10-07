﻿using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace InsuranceApplicationWpfTasklist.Worker
{
    [ExternalTaskTopic("rejectPolicy")]
    [ExternalTaskVariableRequirements("name", "carType", "carManufacturer", "email")]
    class RejectPolicyAdapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            // do nothing here in the demo
        }

    }
}
