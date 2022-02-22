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
    [Route(InternalRoutes.ADITIVO)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class AditivoController : Controller
    {
        private ILogger<AditivoController> _logger { get; }
        private AppDbContext _context { get; }
        public AditivoController(ILogger<AditivoController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todos los aditivos existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ADITIVO_LISTAR)]
        public ActionResult<ApiResponse> ObtenerAditivos()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EAditivo> eAditivos = _context.Aditivo.ToList();
                List<AditivoOutput> aditivos = new();

                foreach (EAditivo eAditivo in eAditivos)
                {
                    aditivos.Add(
                        new AditivoOutput
                        {
                            Id = eAditivo.Id,
                            Name = eAditivo.Name,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = aditivos;
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
        /// Se obtiene la información de un aditivo ingresando su identificador.
        /// </summary>
        /// <param name="aditivoId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ADITIVO_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerAditivo(int aditivoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EAditivo eAditivo = _context.Aditivo.Where(adi => adi.Id == aditivoId).FirstOrDefault();
                if (eAditivo == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AditivoMessages.ADITIVO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                AditivoOutput aditivo = new()
                {
                    Id = eAditivo.Id,
                    Name = eAditivo.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = aditivo;
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
        /// Se recibe la información de un aditivo y se añade a la base de datos.
        /// </summary>
        /// <param name="aditivo"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ADITIVO_NUEVO)]
        public async Task<ActionResult<ApiResponse>> AgregarAditivo([FromBody] AditivoInput aditivo)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otro aditivo con el mismo nombre
                EAditivo eAditivo = _context.Aditivo.FirstOrDefault(adi => adi.Name == aditivo.Name);
                if (eAditivo != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AditivoMessages.ADITIVO_EXISTENTE;
                    apiResponse.Data = aditivo;
                    return BadRequest(apiResponse);
                }

                eAditivo = new()
                {
                    Name = aditivo.Name,
                };
                await _context.Aditivo.AddAsync(eAditivo);
                await _context.SaveChangesAsync();

                AditivoOutput aditivoOutput = new()
                {
                    Id = eAditivo.Id,
                    Name = eAditivo.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = aditivoOutput;
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
        /// Se recibe el identificador de un aditivo y la nueva informacion para actualizarlo.
        /// </summary>
        /// <param name="aditivoId"></param>
        /// <param name="aditivo"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.ADITIVO_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarAditivo(int aditivoId, [FromBody] AditivoInput aditivo)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EAditivo eAditivo = _context.Aditivo.FirstOrDefault(adi => adi.Id == aditivoId);
                if (eAditivo == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AditivoMessages.ADITIVO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eAditivo.Name = aditivo.Name;

                await _context.SaveChangesAsync();

                AditivoOutput aditivoOutput = new()
                {
                    Id = eAditivo.Id,
                    Name = eAditivo.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = aditivoOutput;
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
        /// Se recibe el identificador de un aditivo y este se elimina de la base de datos.
        /// </summary>
        /// <param name="aditivoId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.ADITIVO_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarAditivo(int aditivoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EAditivo eAditivo = _context.Aditivo.FirstOrDefault(adi => adi.Id == aditivoId);
                if (eAditivo == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AditivoMessages.ADITIVO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eAditivo);

                await _context.SaveChangesAsync();

                AditivoOutput aditivoOutput = new()
                {
                    Id = eAditivo.Id,
                    Name = eAditivo.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = aditivoOutput;
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
