using Common.Model;

namespace Common.DTOs
{
    public class WorkflowResponseDTO
    {
        public Business Business { get; set; }
        public List<string> RequiredNext { get; set; }
    }
}
