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
    [Route(InternalRoutes.ANALITICO)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class AnaliticoController : Controller
    {
        private ILogger<AnaliticoController> _logger { get; }
        private AppDbContext _context { get; }
        public AnaliticoController(ILogger<AnaliticoController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todos los analiticos existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ANALITICO_LISTAR)]
        public ActionResult<ApiResponse> ObtenerAnaliticos()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EAnalitico> eAnaliticos = _context.Analitico.ToList();
                List<AnaliticoOutput> analiticos = new();

                foreach (EAnalitico eAnalitico in eAnaliticos)
                {
                    analiticos.Add(
                        new AnaliticoOutput
                        {
                            Id = eAnalitico.Id,
                            Name = eAnalitico.Name,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = analiticos;
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
        /// Se obtiene la información de un analitico ingresando su identificador.
        /// </summary>
        /// <param name="analiticoId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ANALITICO_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerAnalitico(int analiticoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EAnalitico eAnalitico = _context.Analitico.Where(ana => ana.Id == analiticoId).FirstOrDefault();
                if (eAnalitico == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AnaliticoMessages.ANALITICO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                AnaliticoOutput analitico = new()
                {
                    Id = eAnalitico.Id,
                    Name = eAnalitico.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = analitico;
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
        /// Se recibe la información de un analitico y se añade a la base de datos.
        /// </summary>
        /// <param name="analitico"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ANALITICO_NUEVO)]
        public async Task<ActionResult<ApiResponse>> AgregarAnalitico([FromBody] AnaliticoInput analitico)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otro analitico con el mismo nombre
                EAnalitico eAnalitico = _context.Analitico.FirstOrDefault(adi => adi.Name == analitico.Name);
                if (eAnalitico != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AnaliticoMessages.ANALITICO_EXISTENTE;
                    apiResponse.Data = analitico;
                    return BadRequest(apiResponse);
                }

                eAnalitico = new()
                {
                    Name = analitico.Name,
                };
                await _context.Analitico.AddAsync(eAnalitico);
                await _context.SaveChangesAsync();

                AnaliticoOutput analiticoOutput = new()
                {
                    Id = eAnalitico.Id,
                    Name = eAnalitico.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = analiticoOutput;
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
        /// Se recibe el identificador de un analitico y la nueva informacion para actualizarlo.
        /// </summary>
        /// <param name="analiticoId"></param>
        /// <param name="analitico"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.ANALITICO_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarAnalitico(int analiticoId, [FromBody] AnaliticoInput analitico)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EAnalitico eAnalitico = _context.Analitico.FirstOrDefault(ana => ana.Id == analiticoId);
                if (eAnalitico == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AnaliticoMessages.ANALITICO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eAnalitico.Name = analitico.Name;

                await _context.SaveChangesAsync();

                AnaliticoOutput analiticoOutput = new()
                {
                    Id = eAnalitico.Id,
                    Name = eAnalitico.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = analiticoOutput;
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
        /// Se recibe el identificador de un analitico y este se elimina de la base de datos.
        /// </summary>
        /// <param name="analiticoId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.ANALITICO_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarAnalitico(int analiticoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EAnalitico eAnalitico = _context.Analitico.FirstOrDefault(ana => ana.Id == analiticoId);
                if (eAnalitico == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AnaliticoMessages.ANALITICO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eAnalitico);

                await _context.SaveChangesAsync();

                AnaliticoOutput analiticoOutput = new()
                {
                    Id = eAnalitico.Id,
                    Name = eAnalitico.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = analiticoOutput;
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
