using Repository.Entities;

namespace Repository.Dbo
{
    public class CustomerDbo : BaseDbo
    {
        /// <summary>
        /// Retourne la liste des clients 
        /// </summary>
        public static IEnumerable<CustomerEntity> GetAll()
        {
            lock (dbLock)
            {
                return Db.Table<CustomerEntity>();
            }
        }

        /// <summary>
        /// Retourne les informations relatives a un client
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="firstname"></param>
        /// <returns></returns>
        public static CustomerEntity GetByName(string lastname, string firstname)
        {
            lock (dbLock)
            {
                return Db.Query<CustomerEntity>("SELECT * FROM CUSTOMER WHERE LASTNAME = ? AND FIRSTNAME = ?", lastname, firstname).FirstOrDefault();
            }
        }
    }
}
