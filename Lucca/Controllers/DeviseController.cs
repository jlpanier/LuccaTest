using Business;
using Lucca.Request;
using Lucca.Responses;
using Microsoft.AspNetCore.Mvc;
using static Business.MessageException;

namespace Lucca.Controllers
{
    /// <summary>
    /// Gestion des devises
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class DeviseController : BaseController
    {
        public DeviseController(ILogger<DeviseController> logger, IConfiguration configuration):base(logger, configuration)
        {
        }

        /// <summary>
        /// LIste de toutes les devises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ResponseDevises All()
        {
            try
            {
                var items = Devise.All();
                _logger.LogInformation($"All => {items.Count()} rows");
                return ResponseDevises.SuccessResponse(_mode, items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"All => {ex.Message}");
                return ResponseDevises.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Obtenir les informqtions d'une devise
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet()]
        public ResponseDevise Get(string code)
        {
            try
            {
                Devise item = Devise.GetByCode(code);
                if (item == null)
                {
                    throw new MessageException(ErrorType.NotFound);
                }
                _logger.LogInformation($"Get => {item.Code}");
                return ResponseDevise.SuccessResponse(_mode, item);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Get => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Get => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Creation d'une devise
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public ResponseDevise Create([FromBody] RequestDevise data)
        {
            try
            {
                var devise = Devise.InsertOrUpdate(data.Label, data.Code, data.Numero);
                _logger.LogInformation($"Create => {devise.Code}");
                return ResponseDevise.SuccessResponse(_mode, devise);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Create => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Create => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
        }

        /// <summary>
        /// Suppression dúne devise
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseDevise Delete(string code)
        {
            try
            {
                Devise item = Devise.GetByCode(code);
                if (item == null)
                {
                    throw new MessageException(ErrorType.NotFound);
                }
                item.Delete();
                _logger.LogInformation($"Delete => {item.Code}");
                return ResponseDevise.SuccessResponse(_mode, item);
            }
            catch (MessageException ex)
            {
                _logger.LogError(ex, $"MessageException Delete => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception Delete => {ex.Message}");
                return ResponseDevise.BadResponse(_mode, ex.Message);
            }
        }

    }
}