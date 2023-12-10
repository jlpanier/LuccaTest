using Business;

namespace Lucca.Responses
{
    /// <summary>
    /// Reponse basic
    /// </summary>
    public class BaseResponse
    {
        #region Propriétés

        /// <summary>
        /// VRAI si success
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// Message information notament dans le cas d'echecs
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Constante dépendant de l'environemet - 
        /// </summary>
        public string Mode { get; private set; }

        /// <summary>
        /// Volumétrie impactees
        /// </summary>
        public int Count { get; private set; }

        #endregion

        protected BaseResponse(string mode, string message, bool success, int count=0)
        {
            Success = success;
            Message = message;
            Mode = mode;
            Count = count;
        }

    }
}
