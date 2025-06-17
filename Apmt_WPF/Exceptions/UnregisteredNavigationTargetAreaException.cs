namespace Apmt_WPF.Exceptions
{
    public class UnregisteredNavigationTargetAreaException : Exception
    {
        public UnregisteredNavigationTargetAreaException()
        {
        }

        public UnregisteredNavigationTargetAreaException(string? message) : base(message)
        {
        }
    }
}
