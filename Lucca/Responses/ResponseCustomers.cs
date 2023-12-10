using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller CustomerController
    /// </summary>
    public class ResponseCustomers : BaseResponse
    {
        /// <summary>
        /// Clients
        /// </summary>
        public List<Customer> Customers { get; private set; }

        private ResponseCustomers(string mode, string message, bool success, int count = 0) : base(mode, message, success, count)
        {
            Customers = new List<Customer>();
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseCustomers BadResponse(string mode, string message) => new ResponseCustomers(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseCustomers SuccessResponse(string mode, IEnumerable<Customer> items)
        {
            var result = new ResponseCustomers(mode, "Success", true, items.Count());
            result.Customers = new List<Customer>(items);
            return result;
        }
    }
}
