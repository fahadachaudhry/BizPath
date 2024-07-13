namespace Common.Exceptions
{
    public static class ExceptionLookup
    {
        public static readonly string InvalidWorkflowExceptionMessage = "Can't update business status due to one of the following reasons: One or more required fields are missing, the provided information does not satisfy all conditions for a successful stage change, the business has already completed all stages, or the business does not qualify to move any futher.";
        public static readonly string UnsupportedWorkflow = "Unsupported Action for the suggested business/status/industry";
        public static readonly string AlreadyUpToDate = "The business status is already up to date";
    }
}
