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
    [Route(InternalRoutes.INGREDIENTE)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class IngredienteController : Controller
    {
        private ILogger<IngredienteController> _logger { get; }
        private AppDbContext _context { get; }
        public IngredienteController(ILogger<IngredienteController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todos los ingredientes existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.INGREDIENTE_LISTAR)]
        public ActionResult<ApiResponse> ObtenerIngredientes()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<EIngrediente> eIngredientes = _context.Ingrediente.ToList();
                List<IngredienteOutput> ingredientes = new();

                foreach (EIngrediente eIngrediente in eIngredientes)
                {
                    ingredientes.Add(
                        new IngredienteOutput
                        {
                            Id = eIngrediente.Id,
                            Name = eIngrediente.Name,
                            Description = eIngrediente.Description,
                        });
                }

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = ingredientes;
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
        /// Se obtiene la información de un ingrediente ingresando su identificador.
        /// </summary>
        /// <param name="ingredienteId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.INGREDIENTE_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerIngrediente(int ingredienteId)
        {
            ApiResponse apiResponse = new();
            try
            {
                EIngrediente eIngrediente = _context.Ingrediente.Where(ing => ing.Id == ingredienteId).FirstOrDefault();
                if (eIngrediente == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = IngredienteMessages.INGREDIENTE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                IngredienteOutput ingrediente = new()
                {
                    Id = eIngrediente.Id,
                    Name = eIngrediente.Name,
                    Description = eIngrediente.Description,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = ingrediente;
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
        /// Se recibe la información de un ingrediente y se añade a la base de datos.
        /// </summary>
        /// <param name="ingrediente"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.INGREDIENTE_NUEVO)]
        public async Task<ActionResult<ApiResponse>> AgregarIngrediente([FromBody] IngredienteInput ingrediente)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que no exista otro ingrediente con el mismo nombre
                EIngrediente eIngrediente = _context.Ingrediente.FirstOrDefault(ing => ing.Name == ingrediente.Name);
                if (eIngrediente != null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = IngredienteMessages.INGREDIENTE_EXISTENTE;
                    apiResponse.Data = ingrediente;
                    return BadRequest(apiResponse);
                }

                eIngrediente = new()
                {
                    Name = ingrediente.Name,
                    Description = ingrediente.Description,
                };
                await _context.Ingrediente.AddAsync(eIngrediente);
                await _context.SaveChangesAsync();

                IngredienteOutput ingredienteOutput = new()
                {
                    Id = eIngrediente.Id,
                    Name = eIngrediente.Name,
                    Description = eIngrediente.Description
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = ingredienteOutput;
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
        /// Se recibe el identificador de un ingrediente y la nueva información para actualizarlo.
        /// </summary>
        /// <param name="ingredienteId"></param>
        /// <param name="ingrediente"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.INGREDIENTE_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarIngrediente(int ingredienteId, [FromBody] IngredienteInput ingrediente)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EIngrediente eIngrediente = _context.Ingrediente.FirstOrDefault(ing => ing.Id == ingredienteId);
                if (eIngrediente == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = IngredienteMessages.INGREDIENTE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eIngrediente.Name = ingrediente.Name;
                eIngrediente.Description = ingrediente.Description;

                await _context.SaveChangesAsync();

                IngredienteOutput ingredienteOutput = new()
                {
                    Id = eIngrediente.Id,
                    Name = eIngrediente.Name,
                    Description = eIngrediente.Description
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = ingredienteOutput;
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
        /// Se recibe el identificador de un ingrediente y este se elimina de la base de datos.
        /// </summary>
        /// <param name="ingredienteId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.INGREDIENTE_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarIngrediente(int ingredienteId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EIngrediente eIngrediente = _context.Ingrediente.FirstOrDefault(ing => ing.Id == ingredienteId);
                if (eIngrediente == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = IngredienteMessages.INGREDIENTE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eIngrediente);

                await _context.SaveChangesAsync();

                IngredienteOutput ingredienteOutput = new()
                {
                    Id = eIngrediente.Id,
                    Name = eIngrediente.Name,
                    Description = eIngrediente.Description
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = ingredienteOutput;
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
