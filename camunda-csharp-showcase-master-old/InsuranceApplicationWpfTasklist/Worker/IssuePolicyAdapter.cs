﻿using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;



namespace InsuranceApplicationWpfTasklist.Worker
{
    [ExternalTaskTopic("issuePolicy")]
    [ExternalTaskVariableRequirements("name", "carType", "carManufacturer", "email")]
    class IssuePolicyAdapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            // just create an id for demo purposes here
            resultVariables.Add("policyId", Guid.NewGuid().ToString());
        }

    }
}
