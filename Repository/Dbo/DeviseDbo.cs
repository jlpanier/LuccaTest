using Repository.Entities;

namespace Repository.Dbo
{
    public class DeviseDbo: BaseDbo
    {
        /// <summary>
        /// Retourne la liste des devises 
        /// </summary>
        public static IEnumerable<DeviseEntity> GetAll()
        {
            lock (dbLock)
            {
                return Db.Table<DeviseEntity>();
            }
        }

        /// <summary>
        /// Retourne la devise 
        /// </summary>
        public static DeviseEntity GetByCode(string code)
        {
            lock (dbLock)
            {
                IEnumerable<DeviseEntity> items = Db.Query<DeviseEntity>("SELECT * FROM DEVISE WHERE CODE = ?", code);
                return items.FirstOrDefault(); // Un seul code par monnaie => aucun doublon
            }
        }
    }
}
