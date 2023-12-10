using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller TransactionController
    /// </summary>
    public class ResponseTransactions : BaseResponse
    {
        /// <summary>
        /// Reference client
        /// </summary>
        private Customer? _customer;

        /// <summary>
        /// Transactions liées au client
        /// </summary>
        public string Name => _customer == null ? string.Empty : $"{_customer.FirstName} {_customer.LastName}";


        /// <summary>
        /// Transactions liées au client
        /// </summary>
        public List<Transaction> Transactions { get; private set; }

        private ResponseTransactions(string mode, string message, bool success, int count = 0) : base(mode, message, success, count)
        {
            Transactions = new List<Transaction>();
            _customer = null;
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseTransactions BadResponse(string mode, string message) => new ResponseTransactions(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseTransactions SuccessResponse(string mode, Customer customer, IEnumerable<Transaction> items)
        {
            var result = new ResponseTransactions(mode, "Success", true, items.Count());
            result._customer = customer;
            result.Transactions = new List<Transaction>(items);
            return result;
        }
    }
}
