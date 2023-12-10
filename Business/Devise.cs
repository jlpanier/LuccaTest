using Repository.Dbo;
using Repository.Entities;
using System.Text.RegularExpressions;


namespace Business
{
    /// <summary>
    /// https://fr.iban.com/currency-codes
    /// </summary>
    public class Devise
    {
        #region Properties

        /// <summary>
        /// Code de la devise
        /// </summary>
        public string Code => Item.Code;

        /// <summary>
        /// Code numerique de la devise 
        /// </summary>
        public int Numero => Item.Numero;

        /// <summary>
        /// Nom de la devise
        /// </summary>
        public string Label => Item.Devise;

        #endregion

        #region static area

        /// <summary>
        /// Retourne la liste des devises 
        /// </summary>
        public static IEnumerable<Devise> All()
        {
            return DeviseDbo.GetAll().Select(_ => new Devise(_));
        }

        /// <summary>
        /// Retourne la devise
        /// </summary>
        public static Devise GetByCode(string code)
        {
            DeviseEntity item = DeviseDbo.GetByCode(code);
            return item == null ? null : new Devise(item);
        }

        /// <summary>
        /// Mise a jour / insertion de la devise 
        /// </summary>
        public static Devise InsertOrUpdate(string label, string code, int numero)
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException("code");
            }
            if (numero<=0 || numero>1000)
            {
                throw new ArgumentNullException("numero");
            }
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException("label");
            }
            Regex rgx = new Regex("^([A-Z]{3})$");
            if (!rgx.IsMatch(code))
            {
                throw new MessageException(MessageException.ErrorType.BadFormat);
            }

            DeviseEntity item = DeviseDbo.GetByCode(code);
            if (item == null) 
            {
                item = new DeviseEntity()
                {
                    Code = code,
                    Devise = label,
                    DateMaj = DateTime.Now,
                    Numero = numero,
                };
            }
            else
            {
                item.Devise = label;
                item.DateMaj = DateTime.Now;
                item.Numero = numero;
            }
            int rows = DeviseDbo.Save(item);
            return rows == 1 ? new Devise(item) : null;
        }

        #endregion

        protected DeviseEntity Item { get; private set; }

        private Devise(DeviseEntity item) 
        {
            Item = item;
        }

        public int Delete()
        {
            return DeviseDbo.Delete(Item);
        }
    }
}
