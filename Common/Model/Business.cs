using Common.Enums;

namespace Common.Model
{
    public class Business : BaseEntity
    {
        public string FEIN { get; set; }
        public string Name { get; set; }
        public IndustryEnum? Industry { get; set; }
        public Contact? Contact { get; set; }
        public WorkflowStatusEnum? WorkflowStatus { get; set; }
    }
}
