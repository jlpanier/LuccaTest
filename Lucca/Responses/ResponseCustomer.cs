using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller CustomerController
    /// </summary>
    public class ResponseCustomer: BaseResponse
    {
        /// <summary>
        /// Client
        /// </summary>
        public Customer? Customer { get; private set; }

        private ResponseCustomer(string mode, string message, bool success, int count=0) : base(mode, message, success, count)
        {
            Customer = null;
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseCustomer BadResponse(string mode, string message) => new ResponseCustomer(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseCustomer SuccessResponse(string mode, Customer item) 
        {
            var result = new ResponseCustomer(mode, "Success", true, item == null ? 0 : 1);
            result.Customer = item;
            return result;
        }            
    }
}
