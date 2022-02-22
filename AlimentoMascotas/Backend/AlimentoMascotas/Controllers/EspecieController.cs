using AlimentoMascotas.Constants;
using AlimentoMascotas.Entities;
using AlimentoMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlimentoMascotas.Controllers
{
    [Route(InternalRoutes.ESPECIE)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class EspecieController : Controller
    {
        private ILogger<EspecieController> _logger { get; }
        private AppDbContext _context { get; }
        public EspecieController(ILogger<EspecieController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todas las especies existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ESPECIE_LISTAR)]
        public ActionResult<ApiResponse> ObtenerEspecies()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EEspecie> eEspecies = _context.Especie.ToList();
                List<EspecieOutput> especies = new();

                foreach (EEspecie eEspecie in eEspecies)
                {
                    especies.Add(
                        new EspecieOutput
                        {
                            Id = eEspecie.Id,
                            Name = eEspecie.Name,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = especies;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error = true;
                apiResponse.Message = ex.Message;
                apiResponse.Data = null;
                return BadRequest(apiResponse);
            }
        }

        /// <summary>
        /// Se obtiene la información de una especie ingresando su identificador.
        /// </summary>
        /// <param name="especieId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ESPECIE_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerEspecie(int especieId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EEspecie eEspecie = _context.Especie.Where(esp => esp.Id == especieId).FirstOrDefault();
                if (eEspecie == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                EspecieOutput especie = new()
                {
                    Id = eEspecie.Id,
                    Name = eEspecie.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = especie;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error = true;
                apiResponse.Message = ex.Message;
                apiResponse.Data = null;
                return BadRequest(apiResponse);
            }
        }

        /// <summary>
        /// Se recibe la información de una especie y se añade a la base de datos.
        /// </summary>
        /// <param name="especie"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ESPECIE_NUEVA)]
        public async Task<ActionResult<ApiResponse>> AgregarEspecie([FromBody] EspecieInput especie)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otra especie con el mismo nombre
                EEspecie eEspecie = _context.Especie.FirstOrDefault(esp => esp.Name == especie.Name);
                if (eEspecie != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_EXISTENTE;
                    apiResponse.Data = especie;
                    return BadRequest(apiResponse);
                }

                eEspecie = new()
                {
                    Name = especie.Name,
                };
                await _context.Especie.AddAsync(eEspecie);
                await _context.SaveChangesAsync();

                EspecieOutput especieOutput = new()
                {
                    Id = eEspecie.Id,
                    Name = eEspecie.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = especieOutput;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error = true;
                apiResponse.Message = ex.Message;
                apiResponse.Data = null;
                return BadRequest(apiResponse);
            }
        }

        /// <summary>
        /// Se recibe el identificador de una especie y la nueva información para actualizarlo.
        /// </summary>
        /// <param name="especieId"></param>
        /// <param name="especie"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.ESPECIE_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarEspecie(int especieId, [FromBody] EspecieInput especie)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la especie exista
                EEspecie eEspecie = _context.Especie.FirstOrDefault(esp => esp.Id == especieId);
                if (eEspecie == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eEspecie.Name = especie.Name;

                await _context.SaveChangesAsync();

                EspecieOutput especieOutput = new()
                {
                    Id = eEspecie.Id,
                    Name = eEspecie.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = especieOutput;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error = true;
                apiResponse.Message = ex.Message;
                apiResponse.Data = null;
                return BadRequest(apiResponse);
            }
        }

        /// <summary>
        /// Se recibe el identificador de una especie y esta se elimina de la base de datos.
        /// </summary>
        /// <param name="especieId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.ESPECIE_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarEspecie(int especieId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la especie exista
                EEspecie eEspecie = _context.Especie.FirstOrDefault(esp => esp.Id == especieId);
                if (eEspecie == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eEspecie);

                await _context.SaveChangesAsync();

                EspecieOutput especieOutput = new()
                {
                    Id = eEspecie.Id,
                    Name = eEspecie.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = especieOutput;
                return Ok(apiResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                apiResponse.Error = true;
                apiResponse.Message = ex.Message;
                apiResponse.Data = null;
                return BadRequest(apiResponse);
            }
        }
    }
}
