using Business;

namespace Lucca.Request
{
    public class RequestTransaction
    {
        /// <summary>
        /// Date de la transaction
        /// </summary>
        public DateTime EffectiveOn { get; set; }

        /// <summary>
        /// Nom de l'utisateur
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Prénom de l'utisateur
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Code de la nature de la transaction
        /// </summary>
        public string CodeNature { get; set; }

        /// <summary>
        /// Code de la devise de la transaction
        /// </summary>
        public string CodeDevise{ get; set; }

        /// <summary>
        /// Montant de la transaction
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Commentaire lié la transaction
        /// </summary>
        public string Commentaire { get; set; }
    }
}
