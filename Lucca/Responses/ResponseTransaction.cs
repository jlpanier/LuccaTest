using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller TransactionController
    /// </summary>
    public class ResponseTransaction : BaseResponse
    {
        /// <summary>
        /// Transaction
        /// </summary>
        public Transaction? Transaction { get; private set; }

        private ResponseTransaction(string mode, string message, bool success, int count = 0) : base(mode, message, success, count)
        {
            Transaction = null;
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseTransaction BadResponse(string mode, string message) => new ResponseTransaction(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseTransaction SuccessResponse(string mode, Transaction item)
        {
            var result = new ResponseTransaction(mode, "Success", true, item == null ? 0 : 1);
            result.Transaction = item;
            return result;
        }
    }
}
