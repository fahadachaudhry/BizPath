using Common.Enums;
using Common.Model;
using RuleEngine.Interfaces;

namespace RuleEngine.RuleEngines
{
    public class StoreWorkflow : IRuleEngineWorkflow
    {
        public IndustryEnum GetInstanceType()
        {
            return IndustryEnum.STORE;
        }

        public bool CanMoveNext(Business business, ref WorkflowStatusEnum targetStatus)
        {
            if (business.Industry != null
                && business.WorkflowStatus == WorkflowStatusEnum.NEW)
            {
                targetStatus = WorkflowStatusEnum.MARKET_APPROVED;
                return true;
            }
            else if (business.Contact != null
                    && business.WorkflowStatus == WorkflowStatusEnum.MARKET_APPROVED)
            {
                targetStatus = WorkflowStatusEnum.SALES_APPROVED;
                return true;
            }

            return false;
        }

        public List<string> GetRequiredForNextStage(WorkflowStatusEnum status)
        {
            var requiredForNextStage = new List<string>();
            if (status == WorkflowStatusEnum.NEW)
            {
                requiredForNextStage.Add("Industry");
            }
            else if (status == WorkflowStatusEnum.MARKET_APPROVED)
            {
                requiredForNextStage.Add("Contact");
            }

            return requiredForNextStage;
        }

        public Business Win(Business business)
        {
            business.WorkflowStatus = WorkflowStatusEnum.WON;
            return business;
        }

        public Business Lose(Business business)
        {
            business.WorkflowStatus = WorkflowStatusEnum.LOST;
            return business;
        }
    }
}
