using Repository.Dbo;
using Repository.Entities;

namespace Business
{
    /// <summary>
    /// Gestion des transactions
    /// </summary>
    public class Transaction
    {
        #region Nature de la transaction

        public enum NatureType
        {
            [StringValue("Indéfini")]
            [CodeValue("NONE")]
            None,
            [StringValue("Restaurant")]
            [CodeValue("RESTO")]
            Restaurant,
            [StringValue("Hôtel")]
            [CodeValue("HOTEL")]
            Hotel,
            [StringValue("Train")]
            [CodeValue("SNCF")]
            Sncf,
            [StringValue("Miscellaneous")]
            [CodeValue("MIS")]
            Miscellaneous,
        }

        public static NatureType Parse(string data)
        {
            NatureType result = NatureType.None;

            if (!string.IsNullOrEmpty(data)) 
            {
                foreach (NatureType item in Enum.GetValues(typeof(NatureType)))
                {
                    if (item.GetCodeValue() == data)
                    {
                        result = item;
                    }
                }
            }
            return result;
        }

        #endregion

        #region Propriétés

        /// <summary>
        /// Nature de la transaction, Hotel, SNCF...
        /// </summary>
        public string Nature
        {
            get
            {
                if (_nature== NatureType.None)
                {
                    _nature = Parse(_item.CodeNature);
                }
                return _nature.GetCodeValue();
            }
        }
        private NatureType _nature = NatureType.None;

        /// <summary>
        /// Montante de la transaction
        /// </summary>
        public double Amount => _item.Amount;

        /// <summary>
        /// Date de la transaction / de la depense
        /// </summary>
        public DateTime EffectiveOn => _item.EffectiveOn;

        /// <summary>
        /// Devise de la transaction (identique a celle du client sauf si mise a jour)
        /// </summary>
        public Devise Devise
        {
            get
            {
                if (_devise == null) 
                {
                    _devise = Devise.GetByCode(_item.CodeDevise);
                }
                return _devise;
            }
        }
        private Devise _devise;

        /// <summary>
        /// Commentaire lié a la transaction depense
        /// </summary>
        public string Commentaire => _item.Comment;

        #endregion

        /// <summary>
        /// Retourne la liste des transactions pour tout client
        /// </summary>
        public static IEnumerable<Transaction> All()
        {
            return TransactionDbo.GetAll().Select(_ => new Transaction(_));
        }

        /// <summary>
        /// Retourne la liste des transactions pour tout client
        /// </summary>
        public static IEnumerable<Transaction> GetByCustomer(string firstname, string lastname)
        {
            Customer customer = Customer.GetByName(lastname, firstname);
            if (customer == null)
            {
                throw new MessageException(MessageException.ErrorType.InvalidCustomer);
            }
            return TransactionDbo.GetByCustomereId(customer.Id).Select(_ => new Transaction(_));
        }

        /// <summary>
        /// Ajout d une transaction / dépense
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="effectiveOn"></param>
        /// <param name="amount"></param>
        /// <param name="codeNature"></param>
        /// <param name="codeDevise"></param>
        /// <param name="commentaire"></param>
        /// <returns></returns>
        /// <exception cref="MessageException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static Transaction InsertOrUpdate(string firstName, string lastName, DateTime effectiveOn, double amount, string codeNature, string codeDevise, string commentaire)
        {
            if (string.IsNullOrEmpty(commentaire))
            {
                throw new MessageException(MessageException.ErrorType.InvalidComment);
            }
            if (string.IsNullOrEmpty(commentaire.Trim()))
            {
                throw new MessageException(MessageException.ErrorType.InvalidComment);
            }
            if (amount <= 0)
            {
                throw new ArgumentNullException("amount");
            }
            if (effectiveOn>DateTime.Now)
            {
                throw new MessageException(MessageException.ErrorType.InvalidDate);
            }
            if (effectiveOn < DateTime.Now.Date.AddMonths(-3))
            {
                throw new MessageException(MessageException.ErrorType.InvalidDate);
            }
            Customer customer = Customer.GetByName(lastName, firstName);
            if (customer == null)
            {
                throw new MessageException(MessageException.ErrorType.InvalidCustomer);
            }
            if (customer.Devise.Code != codeDevise) 
            {
                throw new MessageException(MessageException.ErrorType.InvalidDevise);
            }
            NatureType nature = Parse(codeNature);
            if (nature == NatureType.None)
            {
                throw new MessageException(MessageException.ErrorType.InvalidNatureTransaction);
            }

            // Inutile de rechercher des transactions au dela de 3 mois
            IEnumerable<TransactionEntity> transactions = TransactionDbo.GetByCustomereId(customer.Id, DateTime.Now.Date.AddMonths(-3));

            // Un utilisateur ne peut pas déclarer deux fois la même dépense (même date et même montant)
            // TODO Meme date signifie meme heure? 
            // TODO Autorisation pour meme montant, meme date et de nature differente
            if (transactions.Any(_=>_.Amount == amount && _.EffectiveOn == effectiveOn && _.CodeNature == codeNature)) 
            {
                throw new MessageException(MessageException.ErrorType.DuplicateTransaction);
            }

            // La devise de la transaction est celle du client
            // Attention, la devise du client peut etre modifiee - il est donc interessant d'enregistrer la devise dans la transacion
            TransactionEntity item = new TransactionEntity()
            {
                DateMaj = DateTime.Now,
                Amount = amount,
                CodeDevise = codeDevise, 
                CodeNature = codeNature,
                CustomerId = customer.Id,
                EffectiveOn = effectiveOn,
                Comment = commentaire,
                ID = Guid.NewGuid(),
            };
            int rows = TransactionDbo.Save(item);
            return rows == 1 ? new Transaction(item) : null;
        }

        private readonly TransactionEntity _item;

        internal Transaction(TransactionEntity item)
        {
            _item = item;
        }
    }
}
