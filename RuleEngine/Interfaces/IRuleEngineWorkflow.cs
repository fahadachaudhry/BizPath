using Common.DTOs;
using Common.Enums;
using Common.Model;

namespace RuleEngine.Interfaces
{
    public interface IRuleEngineWorkflow : IRuleEngine
    {
        public List<string> GetRequiredForNextStage(WorkflowStatusEnum status);
        public bool CanMoveNext(Business business, ref WorkflowStatusEnum targetStatus);
        public Business Win(Business business);
        public Business Lose(Business business);
    }
}
