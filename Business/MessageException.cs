namespace Business
{
    /// <summary>
    /// Exception fonctionnelle de l'application
    /// </summary>
    public class MessageException : Exception
    {
        public enum ErrorType
        {
            [StringValue("Bad Format")]
            BadFormat,
            [StringValue("Not Found")]
            NotFound,
            [StringValue("Unknon devise")]
            UnknonDeviseNotFound,
            [StringValue("Invalid Date")]
            InvalidDate,
            [StringValue("Invalid Comment")]
            InvalidComment,
            [StringValue("Invalid Customer")]
            InvalidCustomer,
            [StringValue("Invalid Devise")]
            InvalidDevise,
            [StringValue("Duplicate Transaction")]
            DuplicateTransaction,
            [StringValue("Invalid Nature Transaction")]
            InvalidNatureTransaction,
        }

        public MessageException()
        {
        }

        public MessageException(string message) : base(message)
        {
        }

        public MessageException(ErrorType error) : base(error.GetStringValue())
        {
        }
    }
}
