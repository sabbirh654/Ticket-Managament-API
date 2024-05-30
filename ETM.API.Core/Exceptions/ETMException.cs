namespace ETM.API.Core.Exceptions
{
    public class ETMException : Exception
    {
        public ETMException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
