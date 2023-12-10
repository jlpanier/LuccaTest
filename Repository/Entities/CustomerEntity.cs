using SQLite;
using System.ComponentModel;

namespace Repository.Entities
{
    [Table("CUSTOMER")]
    public class CustomerEntity : BaseEntity, INotifyPropertyChanged
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
        /// Code de la devise
        /// </summary>
        [Column("LASTNAME")]
        [Indexed]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    NotifyPropertyChanged(nameof(LastName));
                }
            }
        }
        private string _lastName;

        /// <summary>
        /// Numero
        /// </summary>
        [Column("FIRSTNAME")]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    NotifyPropertyChanged(nameof(FirstName));
                }
            }
        }
        private string _firstName;

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
