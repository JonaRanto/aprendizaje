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
    [Route(InternalRoutes.MARCA)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class MarcaController : Controller
    {
        private ILogger<MarcaController> _logger { get; }
        private AppDbContext _context { get; }
        public MarcaController(ILogger<MarcaController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todas las marcas existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.MARCA_LISTAR)]
        public ActionResult<ApiResponse> ObtenerMarcas ()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EMarca> eMarcas = _context.Marca.ToList();
                List<MarcaOutput> marcas = new();

                foreach (EMarca eMarca in eMarcas)
                {
                    marcas.Add(
                        new MarcaOutput
                        {
                            Id = eMarca.Id,
                            Name = eMarca.Name,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = marcas;
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
        /// Se obtiene la información de una marca ingresando su identificador.
        /// </summary>
        /// <param name="marcaId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.MARCA_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerMarca(int marcaId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EMarca eMarca = _context.Marca.Where(mar => mar.Id == marcaId).FirstOrDefault();
                if (eMarca == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                MarcaOutput marca = new()
                {
                    Id = eMarca.Id,
                    Name = eMarca.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = marca;
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
        /// Se recibe la información de una marca y se añade a la base de datos.
        /// </summary>
        /// <param name="marca"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.MARCA_NUEVA)]
        public async Task<ActionResult<ApiResponse>> AgregarMarca([FromBody] MarcaInput marca)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otra marca con el mismo nombre
                EMarca eMarca = _context.Marca.FirstOrDefault(mar => mar.Name == marca.Name);
                if (eMarca != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_EXISTENTE;
                    apiResponse.Data = marca;
                    return BadRequest(apiResponse);
                }

                eMarca = new()
                {
                    Name = marca.Name,
                };
                await _context.Marca.AddAsync(eMarca);
                await _context.SaveChangesAsync();

                MarcaOutput marcaOutput = new()
                {
                    Id = eMarca.Id,
                    Name = eMarca.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = marcaOutput;
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
        /// Se recibe el identificador de una marca y la nueva información para actualizarlo.
        /// </summary>
        /// <param name="marcaId"></param>
        /// <param name="marca"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.MARCA_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarMarca(int marcaId, [FromBody] MarcaInput marca)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la marca exista
                EMarca eMarca = _context.Marca.FirstOrDefault(mar => mar.Id == marcaId);
                if (eMarca == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eMarca.Name = marca.Name;

                await _context.SaveChangesAsync();

                MarcaOutput marcaOutput = new()
                {
                    Id = eMarca.Id,
                    Name = eMarca.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = marcaOutput;
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
        /// Se recibe el identificador de una marca y esta se elimina de la base de datos.
        /// </summary>
        /// <param name="marcaId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.MARCA_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarMarca(int marcaId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que la marca exista
                EMarca eMarca = _context.Marca.FirstOrDefault(mar => mar.Id == marcaId);
                if (eMarca == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eMarca);

                await _context.SaveChangesAsync();

                MarcaOutput marcaOutput = new()
                {
                    Id = eMarca.Id,
                    Name = eMarca.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = marcaOutput;
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
