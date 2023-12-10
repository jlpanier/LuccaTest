using SQLite;
using System.ComponentModel;

namespace Repository.Entities
{
    /// <summary>
    /// Liste des devises 
    /// cf. https://www.atlas-monde.net/devises-iso-4217/
    /// </summary>
    [Table("DEVISE")]
    public class DeviseEntity : BaseEntity, INotifyPropertyChanged
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

        /// <summary>
        /// Code de la devise
        /// </summary>
        [Column("CODE")]
        [PrimaryKey]
        public string Code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    NotifyPropertyChanged(nameof(Code));
                }
            }
        }
        private string _code;

        /// <summary>
        /// Code numerique de la devise 
        /// </summary>
        [Column("NUMERO")]
        public int Numero
        {
            get { return _numero; }
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                    NotifyPropertyChanged(nameof(Numero));
                }
            }
        }
        private int _numero;

        /// <summary>
        /// Nom de la devise
        /// </summary>
        [Column("DEVISE")]
        public string Devise
        {
            get { return _devise; }
            set
            {
                if (_devise != value)
                {
                    _devise = value;
                    NotifyPropertyChanged(nameof(Devise));
                }
            }
        }
        private string _devise;

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
