namespace Common.Exceptions
{
    public class InvalidWorkflowException : Exception
    {
        public InvalidWorkflowException() { }
        public InvalidWorkflowException(string message) : base(message) { }
        public InvalidWorkflowException(string message, Exception inner) : base(message, inner) { }
    }
}
