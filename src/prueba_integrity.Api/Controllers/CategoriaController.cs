using Microsoft.AspNetCore.Mvc;
using modelo_canonico.Types;
using prueba_integrity.Application.Contracts;
using prueba_integrity.Domain.Responses;
using prueba_integrity.Infraestructure.Configuration;

namespace prueba_integrity.Api.Controllers
{
    [Route("api/" + General.NombreApi + "/[controller]")]
    [Tags(General.NombreApi)]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly ICategoriaContract _contract;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaContract contract)
        {
            _logger = logger;
            _contract = contract;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseCategoria), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> GetAllCategorias()
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller");
                List<CategoriaType>? ListType = await _contract.GetAllCategorias();
                if (ListType.Count is 0) return StatusCode(StatusCodes.Status404NotFound, "No hay datos registrados");
                ResponseCategoria res = new ResponseCategoria
                {
                    TotalRegistros = ListType.Count,
                    Categoria = ListType
                };
                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(General.NombreApi + " - Error Metodo Controller" + ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("finaliza metodo controller");
            }
        }

        [HttpGet("/{id}")]
        [ProducesResponseType(typeof(CategoriaType), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> GetCategoriaid(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller");
                CategoriaType? type = await _contract.GetCategoriaID(id);
                if (type is null) return StatusCode(StatusCodes.Status404NotFound, "No hay datos registrados");
                return StatusCode(StatusCodes.Status200OK, type);
            }
            catch (Exception ex)
            {
                _logger.LogError(General.NombreApi + " - Error Metodo Controller" + ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("finaliza metodo controller");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> CreateCategoria([FromBody] CategoriaType categoria)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller");
                bool res = await _contract.CreateCategoria(categoria);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Puede que existan datos similares");

                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(General.NombreApi + " - Error Metodo Controller" + ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("finaliza metodo controller");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> UpdateCategoria([FromBody] CategoriaType categoria)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller");
                bool res = await _contract.UpdateCategoria(categoria);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Puede que no existan datos similares");

                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(General.NombreApi + " - Error Metodo Controller" + ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("finaliza metodo controller");
            }
        }

        [HttpDelete("/{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            try
            {
                _logger.LogInformation("Inicia metodo controller");
                bool res = await _contract.DeleteCategoria(id);
                if (res is false) return StatusCode(StatusCodes.Status404NotFound, "Puede que no existan datos similares");

                return StatusCode(StatusCodes.Status200OK, res);
            }
            catch (Exception ex)
            {
                _logger.LogError(General.NombreApi + " - Error Metodo Controller" + ex);
                throw;
            }
            finally
            {
                _logger.LogInformation("finaliza metodo controller");
            }
        }
    }
}
