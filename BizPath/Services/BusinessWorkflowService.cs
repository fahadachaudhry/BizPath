using BizPath.Interfaces;
using Common.DTOs;
using Common.Enums;
using Common.Exceptions;
using Common.Model;
using RuleEngine.Interfaces;

namespace BizPath.Services
{
    public class BusinessWorkflowService : IBusinessWorkflowService
    {
        private readonly Dictionary<IndustryEnum, IRuleEngineWorkflow> _polymorphicRuleEngineLookup;

        public BusinessWorkflowService(IEnumerable<IRuleEngineWorkflow> ruleEngines)
        {
            _polymorphicRuleEngineLookup = [];
            foreach (var ruleEngine in ruleEngines)
            {
                _polymorphicRuleEngineLookup.Add(ruleEngine.GetInstanceType(), ruleEngine);
            }
        }

        public WorkflowResponseDTO CreateNew()
        {
            var business = GetRandomNewBusiness();

            WorkflowResponseDTO response = new WorkflowResponseDTO
            {
                Business = business,
                RequiredNext = new List<string>
                {
                    "Industry"
                }
            };

            return response;
        }

        public WorkflowResponseDTO MoveNext(Business business)
        {
            var workflowHandler = GetWorkflowHandler((IndustryEnum)business.Industry);

            WorkflowStatusEnum status = WorkflowStatusEnum.NEW;
            var movedForward = workflowHandler.CanMoveNext(business, ref status);
            business.WorkflowStatus = status;
            
            if (!movedForward)
            {
                throw new InvalidWorkflowException(ExceptionLookup.InvalidWorkflowExceptionMessage);
            }

            return new WorkflowResponseDTO
            {
                Business = business,
                RequiredNext = workflowHandler.GetRequiredForNextStage((WorkflowStatusEnum)business.WorkflowStatus)
            };
        }

        public Business Win(Business business)
        {
            var workflowHandler = GetWorkflowHandler((IndustryEnum)business.Industry);
            return workflowHandler.Win(business);
        }
        
        public Business Lose(Business business)
        {
            var workflowHandler = GetWorkflowHandler((IndustryEnum)business.Industry);
            return workflowHandler.Lose(business);
        }

        private IRuleEngineWorkflow GetWorkflowHandler(IndustryEnum industry)
        {
            return _polymorphicRuleEngineLookup[industry];
        }

        private Business GetRandomNewBusiness()
        {
            return new Business
            {
                Id = new Guid(),
                FEIN = "12345678",
                Name = "Acme Inc",
                WorkflowStatus = WorkflowStatusEnum.NEW
            };
        }
    }
}
