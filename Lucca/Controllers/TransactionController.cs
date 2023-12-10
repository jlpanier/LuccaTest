using Business;
using Lucca.Request;
using Lucca.Responses;
using Microsoft.AspNetCore.Mvc;
using static Business.MessageException;

namespace Lucca.Controllers
{
    /// <summary>
    /// Gestion des transactions / dépenses
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransactionController : BaseController
    {
        #region Ordre de tri 

        public enum OrderType
        {
            [StringValue("Indéfini")]
            [CodeValue("NONE")]
            None,
            [StringValue("Montant")]
            [CodeValue("amount")]
            Amount,
            [StringValue("Date")]
            [CodeValue("date")]
            Date,
        }

        public static OrderType Parse(string data)
        {
            OrderType result = OrderType.None;

            if (!string.IsNullOrEmpty(data))
            {
                foreach (OrderType item in Enum.GetValues(typeof(OrderType)))
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

        public TransactionController(ILogger<TransactionController> logger, IConfiguration configuration):base(logger, configuration)
        {
        }

        /// <summary>
        /// Obtenir les transactions / dépenses d'un client
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="orderby"></param>
        /// <returns></returns>
        [HttpGet()]
        public ResponseTransactions Get(string firstname, string lastname, string orderby = null)
        {
            try
            {
                Customer customer = Customer.GetByName(lastname, firstname);
                if (customer == null)
                {
                    _logger.LogDebug($"Get => customer {lastname} {firstname} not found");
                    throw new MessageException(MessageException.ErrorType.InvalidCustomer);
                }
                IEnumerable<Transaction> items = customer.GetTransactions();
                if (items == null || !items.Any())
                {
                    _logger.LogDebug($"Get => customer {lastname} {firstname} no transactions");
                    throw new MessageException(ErrorType.NotFound);
                }

                // on peut se demander pourquoi trier les transactions (n'est-ce pas a l'application appelante de le faire?
                OrderType ordertype = Parse(orderby);
                switch (ordertype)
                {
                    case OrderType.Amount:
                        return ResponseTransactions.SuccessResponse(_mode, customer, items.OrderBy(_=>_.Amount));

                    default: 
                        // par defaut, le tri s'effectue sur la date - non prise en compte d'un tri par date descendante
                        return ResponseTransactions.SuccessResponse(_mode, customer, items.OrderBy(_ => _.EffectiveOn));
                }
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Get => {ex.Message}");
                return ResponseTransactions.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Get => {ex.Message}");
                return ResponseTransactions.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Creation d'une transaction / dépense pour un client
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ResponseTransaction> Create([FromBody] RequestTransaction data)
        {
            try
            {
                if (data == null)
                {
                    throw new MessageException(ErrorType.BadFormat);
                }
                Transaction item = Transaction.InsertOrUpdate(data.FirstName, data.LastName, data.EffectiveOn, data.Amount, data.CodeNature, data.CodeDevise, data.Commentaire);
                _logger.LogInformation($"Create => name {data.FirstName} {data.LastName} on {data.EffectiveOn}  amount {data.Amount} {data.CodeDevise} nature {data.CodeNature} commentaire {data.Commentaire}");
                return ResponseTransaction.SuccessResponse(_mode, item);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Create => {ex.Message}");
                return ResponseTransaction.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Create => {ex.Message}");
                return ResponseTransaction.BadResponse(_mode, ex.Message);
            }
        }
    }
}