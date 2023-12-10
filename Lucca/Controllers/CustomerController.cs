using Business;
using Lucca.Responses;
using Microsoft.AspNetCore.Mvc;
using static Business.MessageException;

namespace Lucca.Controllers
{
    /// <summary>
    /// Gestion des clients
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : BaseController
    {
        public CustomerController(ILogger<CustomerController> logger, IConfiguration configuration):base(logger, configuration)
        {
        }

        /// <summary>
        /// Obtenir la liste des clients
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseCustomers All()
        {
            try
            {
                var items = Customer.All();
                _logger.LogInformation($"All => {items.Count()} rows");
                return ResponseCustomers.SuccessResponse(_mode, items);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"All => {ex.Message}");
                return ResponseCustomers.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Information sur un client
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="firstname"></param>
        /// <returns></returns>
        [HttpGet()]
        public ResponseCustomer Get(string lastname, string firstname)
        {
            try
            {
                Customer item = Customer.GetByName(lastname, firstname);
                if (item == null)
                {
                    throw new MessageException(ErrorType.NotFound);
                }
                _logger.LogInformation($"Get => {item.Name}");
                return ResponseCustomer.SuccessResponse(_mode, item);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Get => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Get => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Creation dún client
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="codedevise"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ResponseCustomer> Create(string firstname, string lastname, string codedevise)
        {
            try
            {
                var customer = Customer.InsertOrUpdate(firstname, lastname, codedevise);
                _logger.LogInformation($"Create => {customer.Name}");
                return ResponseCustomer.SuccessResponse(_mode, customer);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Create => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Create => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Supprimer un client
        /// </summary>
        /// <param name="lastname"></param>
        /// <param name="firstname"></param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseCustomer Delete(string lastname, string firstname)
        {
            try
            {
                Customer customer = Customer.GetByName(lastname, firstname);
                if (customer == null)
                {
                    throw new MessageException(ErrorType.NotFound);
                }
                customer.Delete();
                _logger.LogInformation($"Delete => {customer.Name}");
                return ResponseCustomer.SuccessResponse(_mode, customer);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Delete => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Delete => {ex.Message}");
                return ResponseCustomer.BadResponse(_mode, ex.Message);
            }
        }

    }
}