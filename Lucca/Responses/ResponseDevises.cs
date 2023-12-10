using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller DeviseController
    /// </summary>
    public class ResponseDevises : BaseResponse
    {
        /// <summary>
        /// Devises
        /// </summary>
        public List<Devise> Devises { get; private set; }

        private ResponseDevises(string mode, string message, bool success, int count = 0) : base(mode, message, success, count)
        {
            Devises = new List<Devise>();
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseDevises BadResponse(string mode, string message) => new ResponseDevises(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseDevises SuccessResponse(string mode, IEnumerable<Devise> items)
        {
            var result = new ResponseDevises(mode, "Success", true, items.Count());
            result.Devises = new List<Devise>(items);
            return result;
        }
    }
}
