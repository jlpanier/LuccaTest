using Repository.Entities;

namespace Repository.Dbo
{
    public class TransactionDbo: BaseDbo
    {
        /// <summary>
        /// Retourne les transactions
        /// </summary>
        public static IEnumerable<TransactionEntity> GetAll()
        {
            lock (dbLock)
            {
                return Db.Query<TransactionEntity>("SELECT * FROM TRANSACTIONS");
            }
        }

        /// <summary>
        /// Retourne les transactions liées a un client 
        /// </summary>
        public static IEnumerable<TransactionEntity> GetByCustomereId(Guid customerid)
        {
            lock (dbLock)
            {
                return Db.Query<TransactionEntity>("SELECT * FROM TRANSACTIONS WHERE CUSTOMERID = ?", customerid);
            }
        }

        /// <summary>
        /// Retourne les transactions liées a un client 
        /// </summary>
        public static IEnumerable<TransactionEntity> GetByCustomereId(Guid customerid, DateTime dt)
        {
            lock (dbLock)
            {
                return Db.Query<TransactionEntity>("SELECT * FROM TRANSACTIONS WHERE CUSTOMERID = ? AND EFFECTIVEON > ?", customerid, dt);
            }
        }
    }
}
