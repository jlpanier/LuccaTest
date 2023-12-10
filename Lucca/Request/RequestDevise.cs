namespace Lucca.Request
{
    public class RequestDevise
    {
        /// <summary>
        /// Code de la devise
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Code numerique de la devise 
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Nom de la devise
        /// </summary>
        public string Label { get; set; }
    }
}
