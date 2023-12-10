using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse du controller DeviseController
    /// </summary>
    public class ResponseDevise : BaseResponse
    {
        /// <summary>
        /// Devise
        /// </summary>
        public Devise? Devise { get; private set; }

        private ResponseDevise(string mode, string message, bool success, int count = 0) : base(mode, message, success, count)
        {
            Devise = null;
        }

        /// <summary>
        /// Mauvaise reponse du WS
        /// </summary>
        public static ResponseDevise BadResponse(string mode, string message) => new ResponseDevise(mode, message, false);

        /// <summary>
        /// Success reponse du WS
        /// </summary>
        public static ResponseDevise SuccessResponse(string mode, Devise item)
        {
            var result = new ResponseDevise(mode, "Success", true, item == null ? 0 : 1);
            result.Devise = item;
            return result;
        }
    }
}
