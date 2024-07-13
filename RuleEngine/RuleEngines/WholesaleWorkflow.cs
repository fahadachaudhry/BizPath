using Common.Enums;
using Common.Exceptions;
using Common.Model;
using RuleEngine.Interfaces;

namespace RuleEngine.RuleEngines
{
    public class WholesaleWorkflow : IRuleEngineWorkflow
    {
        public IndustryEnum GetInstanceType()
        {
            return IndustryEnum.WHOLESALE;
        }
        public bool CanMoveNext(Business business, ref WorkflowStatusEnum targetStatus)
        {
            throw new InvalidWorkflowException(ExceptionLookup.UnsupportedWorkflow);
        }

        public List<string> GetRequiredForNextStage(WorkflowStatusEnum status)
        {
            throw new InvalidWorkflowException(ExceptionLookup.UnsupportedWorkflow);
        }

        public Business Win(Business business)
        {
            throw new InvalidWorkflowException(ExceptionLookup.UnsupportedWorkflow);
        }

        public Business Lose(Business business)
        {
            throw new InvalidWorkflowException(ExceptionLookup.UnsupportedWorkflow);
        }
    }
}
