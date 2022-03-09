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
    [Route(InternalRoutes.SIZE)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class SizeController : Controller
    {
        private ILogger<SizeController> _logger { get; }
        private AppDbContext _context { get; }
        public SizeController(ILogger<SizeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todos los sizes existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.SIZE_LISTAR)]
        public ActionResult<ApiResponse> ObtenerSizes()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<ESize> eSizes = _context.Size.ToList();
                List<SizeOutput> sizes = new();

                foreach (ESize eSize in eSizes)
                {
                    sizes.Add(
                        new SizeOutput
                        {
                            Id = eSize.Id,
                            Size = eSize.Size,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = sizes;
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
        /// Se obtiene la información de un size ingresando su identificador.
        /// </summary>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.SIZE_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerSize(int sizeId)
        {
            ApiResponse apiResponse = new();
            try
            {
                ESize eSize = _context.Size.Where(siz => siz.Id == sizeId).FirstOrDefault();
                if (eSize == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = SizeMessages.SIZE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                SizeOutput size = new()
                {
                    Id = eSize.Id,
                    Size = eSize.Size,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = size;
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
        /// Se recibe la información de un size y se añade a la base de datos.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.SIZE_NUEVO)]
        public async Task<ActionResult<ApiResponse>> AgregarSize([FromBody] SizeInput size)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otro size con el mismo dato
                ESize eSize = _context.Size.FirstOrDefault(siz => siz.Size == size.Size);
                if (eSize != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = SizeMessages.SIZE_EXISTENTE;
                    apiResponse.Data = size;
                    return BadRequest(apiResponse);
                }

                eSize = new()
                {
                    Size = size.Size,
                };
                await _context.Size.AddAsync(eSize);
                await _context.SaveChangesAsync();

                SizeOutput sizeOutput = new()
                {
                    Id = eSize.Id,
                    Size = eSize.Size,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = sizeOutput;
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
        /// Se recibe el identificador de un size y la nueva información para actualizarlo.
        /// </summary>
        /// <param name="sizeId"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.SIZE_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarSize(int sizeId, [FromBody] SizeInput size)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el size exista
                ESize eSize = _context.Size.FirstOrDefault(siz => siz.Id == sizeId);
                if (eSize == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = SizeMessages.SIZE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eSize.Size = size.Size;

                await _context.SaveChangesAsync();

                SizeOutput sizeOutput = new()
                {
                    Id = eSize.Id,
                    Size = eSize.Size,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = sizeOutput;
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
        /// Se recibe el identificador de un size y este se elimina de la base de datos.
        /// </summary>
        /// <param name="sizeId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.SIZE_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarSize(int sizeId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el size exista
                ESize eSize = _context.Size.FirstOrDefault(siz => siz.Id == sizeId);
                if (eSize == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = SizeMessages.SIZE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eSize);

                await _context.SaveChangesAsync();

                SizeOutput sizeOutput = new()
                {
                    Id = eSize.Id,
                    Size = eSize.Size,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = sizeOutput;
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
