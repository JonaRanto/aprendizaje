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
    [Route(InternalRoutes.ETAPA)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class EtapaController : Controller
    {
        private ILogger<EtapaController> _logger { get; }
        private AppDbContext _context { get; }
        public EtapaController(ILogger<EtapaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todas las etapas existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ETAPA_LISTAR)]
        public ActionResult<ApiResponse> ObtenerEtapas()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EEtapa> eEtapas = _context.Etapa.ToList();
                List<EtapaOutput> etapas = new();

                foreach (EEtapa eEtapa in eEtapas)
                {
                    etapas.Add(
                        new EtapaOutput
                        {
                            Id = eEtapa.Id,
                            Name = eEtapa.Name,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = etapas;
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
        /// Se obtiene la información de una etapa ingresando su identificador.
        /// </summary>
        /// <param name="etapaId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ETAPA_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerEtapa(int etapaId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EEtapa eEtapa = _context.Etapa.Where(eta => eta.Id == etapaId).FirstOrDefault();
                if (eEtapa == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                EtapaOutput etapa = new()
                {
                    Id = eEtapa.Id,
                    Name = eEtapa.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = etapa;
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
        /// Se recibe la información de una etapa y se añade a la base de datos.
        /// </summary>
        /// <param name="etapa"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ETAPA_NUEVA)]
        public async Task<ActionResult<ApiResponse>> AgregarEtapa([FromBody] EtapaInput etapa)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otra etapa con el mismo nombre
                EEtapa eEtapa = _context.Etapa.FirstOrDefault(eta => eta.Name == etapa.Name);
                if (eEtapa != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_EXISTENTE;
                    apiResponse.Data = etapa;
                    return BadRequest(apiResponse);
                }

                eEtapa = new()
                {
                    Name = etapa.Name,
                };
                await _context.Etapa.AddAsync(eEtapa);
                await _context.SaveChangesAsync();

                EtapaOutput etapaOutput = new()
                {
                    Id = eEtapa.Id,
                    Name = eEtapa.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = etapaOutput;
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
        /// Se recibe el identificador de una etapa y la nueva información para actualizarlo.
        /// </summary>
        /// <param name="etapaId"></param>
        /// <param name="etapa"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.ETAPA_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarEtapa(int etapaId, [FromBody] EtapaInput etapa)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la etapa exista
                EEtapa eEtapa = _context.Etapa.FirstOrDefault(eta => eta.Id == etapaId);
                if (eEtapa == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eEtapa.Name = etapa.Name;

                await _context.SaveChangesAsync();

                EtapaOutput etapaOutput = new()
                {
                    Id = eEtapa.Id,
                    Name = eEtapa.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = etapaOutput;
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
        /// Se recibe el identificador de una etapa y esta se elimina de la base de datos.
        /// </summary>
        /// <param name="etapaId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.ETAPA_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarEtapa(int etapaId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la etapa exista
                EEtapa eEtapa = _context.Etapa.FirstOrDefault(eta => eta.Id == etapaId);
                if (eEtapa == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eEtapa);

                await _context.SaveChangesAsync();

                EtapaOutput etapaOutput = new()
                {
                    Id = eEtapa.Id,
                    Name = eEtapa.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = etapaOutput;
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
