using Common.DTOs;
using Common.Enums;
using Common.Model;

namespace BizPath.Interfaces
{
    public interface IBusinessWorkflowService
    {
        public WorkflowResponseDTO CreateNew();
        public WorkflowResponseDTO MoveNext(Business business);
        public Business Win(Business business);
        public Business Lose(Business business);
    }
}
