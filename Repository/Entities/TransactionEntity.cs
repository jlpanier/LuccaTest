using SQLite;
using System.ComponentModel;

namespace Repository.Entities
{
    [Table("TRANSACTIONS")]
    public class TransactionEntity : BaseEntity, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            IsDirty = true;
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [Ignore]
        public bool IsDirty { get; set; }

        #endregion

        #region Fields/Properties

        [PrimaryKey]
        [Column("ID")]
        public Guid ID
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }
        private Guid _id;

        /// <summary>
        /// Reference client
        /// </summary>
        [Column("CUSTOMERID")]
        [Indexed]
        public Guid CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    _customerId = value;
                    NotifyPropertyChanged(nameof(CustomerId));
                }
            }
        }
        private Guid _customerId;

        /// <summary>
        /// Date de la transaction
        /// </summary>
        [Column("EFFECTIVEON")]
        public DateTime EffectiveOn
        {
            get { return _effectiveOn; }
            set
            {
                if (_effectiveOn != value)
                {
                    _effectiveOn = value;
                    NotifyPropertyChanged(nameof(EffectiveOn));
                }
            }
        }
        private DateTime _effectiveOn;

        /// <summary>
        /// Devise dans laquelle le client effectue ses dépenses
        /// </summary>
        [Column("CODEDEVISE")]
        public string CodeDevise
        {
            get { return _codeDevise; }
            set
            {
                if (_codeDevise != value)
                {
                    _codeDevise = value;
                    NotifyPropertyChanged(nameof(CodeDevise));
                }
            }
        }
        private string _codeDevise;

        /// <summary>
        /// Code de la nature de la transaction
        /// </summary>
        [Column("CODENATURE")]
        public string CodeNature
        {
            get { return _codeNature; }
            set
            {
                if (_codeNature != value)
                {
                    _codeNature = value;
                    NotifyPropertyChanged(nameof(CodeNature));
                }
            }
        }
        private string _codeNature;

        /// <summary>
        /// Montant de la transaction 
        /// </summary>
        [Column("AMOUNT")]
        public double Amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    NotifyPropertyChanged(nameof(Amount));
                }
            }
        }
        private double _amount;

        /// <summary>
        /// Montant de la transaction 
        /// </summary>
        [Column("COMMENTAIRE")]
        public string Comment
        {
            get { return _comment; }
            set
            {
                if (_comment != value)
                {
                    _comment = value;
                    NotifyPropertyChanged(nameof(Comment));
                }
            }
        }
        private string _comment;

        /// <summary>
        /// Date de mise a jour de la ligne 
        /// </summary>
        [Column("DATEMAJ")]
        public DateTime DateMaj
        {
            get { return _datemaj; }
            set
            {
                if (_datemaj != value)
                {
                    _datemaj = value;
                    NotifyPropertyChanged(nameof(DateMaj));
                }
            }
        }
        private DateTime _datemaj;

        #endregion

    }
}
