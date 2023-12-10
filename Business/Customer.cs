using Repository.Dbo;
using Repository.Entities;
using System.Text.RegularExpressions;

namespace Business
{
    /// <summary>
    /// Gestion des clients
    /// </summary>
    public class Customer
    {
        #warning Les proprietes clients ne permettent pas d'identifier des clients homonymes 

        /// <summary>
        /// Retourne la liste de tous les clients
        /// </summary>
        public static IEnumerable<Customer> All()
        { 
            return CustomerDbo.GetAll().Select(_ => new Customer(_));
        }

        /// <summary>
        /// Retourne la liste de tous les clients
        /// </summary>
        public static Customer GetByName(string lastname, string firstname)
        {
            CustomerEntity item = CustomerDbo.GetByName(lastname, firstname);
            return item == null ? null : new Customer(item);
        }


        /// <summary>
        /// Mise a jour / insertion de la devise 
        /// </summary>
        public static Customer InsertOrUpdate(string firstname, string lastname, string codedevise)
        {
            if (string.IsNullOrEmpty(lastname))
            {
                throw new ArgumentNullException("lastname");
            }
            if (string.IsNullOrEmpty(lastname.Trim()))
            {
                throw new ArgumentNullException("lastname");
            }
            if (string.IsNullOrEmpty(firstname))
            {
                throw new ArgumentNullException("firstname");
            }
            if (string.IsNullOrEmpty(firstname.Trim()))
            {
                throw new ArgumentNullException("firstname");
            }
            if (string.IsNullOrEmpty(codedevise))
            {
                throw new ArgumentNullException("codedevise");
            }
            if (string.IsNullOrEmpty(codedevise.Trim()))
            {
                throw new ArgumentNullException("codedevise");
            }
            Devise devise = Devise.GetByCode(codedevise);
            if (devise == null) 
            {
                throw new MessageException(MessageException.ErrorType.UnknonDeviseNotFound);
            }
            Regex rgx = new Regex("^[A-Za-z êëçæàéîïôù,.'-]+$");
            if (!rgx.IsMatch(lastname))
            {
                throw new MessageException(MessageException.ErrorType.BadFormat);
            }
            if (!rgx.IsMatch(firstname))
            {
                throw new MessageException(MessageException.ErrorType.BadFormat);
            }
            CustomerEntity item = CustomerDbo.GetByName(lastname, firstname);
            if (item == null)
            {
                item = new CustomerEntity()
                {
                    LastName = lastname,
                    FirstName = firstname,
                    DateMaj = DateTime.Now,
                    CodeDevise = codedevise,
                    ID = Guid.NewGuid(),
                };
            }
            else
            {
                item.DateMaj = DateTime.Now;
                item.CodeDevise = codedevise;
            }
            int rows = CustomerDbo.Save(item);
            return rows == 1 ? new Customer(item) : null;
        }

        /// <summary>
        /// Retourne la liste des transactions du client
        /// </summary>
        public IEnumerable<Transaction> GetTransactions() => TransactionDbo.GetByCustomereId(Id).Select(_ => new Transaction(_));

        #region properties

        /// <summary>
        /// Reference du client
        /// </summary>
        public Guid Id => _item.ID;

        /// <summary>
        /// Nom du client
        /// </summary>
        public string LastName => _item.LastName;

        /// <summary>
        /// Prenom du client
        /// </summary>
        public string FirstName => _item.FirstName;

        /// <summary>
        /// Nom complet
        /// </summary>
        public string Name => $"{FirstName} {LastName}";

        /// <summary>
        /// Devise du client
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
        private Devise _devise = null;

        #endregion

        /// <summary>
        /// Information client
        /// </summary>
        /// <param name="item"></param>
        private CustomerEntity _item;

        private Customer(CustomerEntity item)
        {
            _item = item;
        }

        /// <summary>
        /// Suppression du client
        /// </summary>
        /// <returns></returns>
        public int Delete() => CustomerDbo.Delete(_item);
    }
}
