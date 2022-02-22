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
    [Route(InternalRoutes.ALIMENTO)]
    [ApiController]
    [Produces(ConfigControllers.DEFAULT_OUTPUT_FORMAT)]
    public class AlimentoController : Controller
    {
        private ILogger<AlimentoController> _logger { get; }
        private AppDbContext _context { get; }
        public AlimentoController(ILogger<AlimentoController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Se obtiene una lista de todos los alimentos existentes en la base de datos.
        /// </summary>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ALIMENTO_LISTAR)]
        public ActionResult<ApiResponse> ObtenerAlimentos()
        {
            ApiResponse apiResponse = new();
            try
            {
                List<AlimentoOutput> alimentos = _context.Alimento
                    .Join(_context.Marca,
                    ali => ali.MarcaId,
                    mar => mar.Id,
                    (ali, mar) => new { ali, mar })
                    .Join(_context.Especie,
                    ali_mar => ali_mar.ali.EspecieId,
                    esp => esp.Id,
                    (ali_mar, esp) => new { ali_mar, esp })
                    .Join(_context.Etapa,
                    ali_mar_esp => ali_mar_esp.ali_mar.ali.EtapaId,
                    eta => eta.Id,
                    (ali_mar_esp, eta) => new AlimentoOutput
                    {
                        Id = ali_mar_esp.ali_mar.ali.Id,
                        Name = ali_mar_esp.ali_mar.ali.Name,
                        Size = ali_mar_esp.ali_mar.ali.Size,
                        Marca = ali_mar_esp.ali_mar.mar.Name,
                        Especie = ali_mar_esp.esp.Name,
                        Etapa = eta.Name,
                        LastUpdate = ali_mar_esp.ali_mar.ali.LastUpdate
                    }).ToList();

                foreach (AlimentoOutput alimento in alimentos)
                {
                    List<IngredienteEnAlimentoOutput> ingredientes = _context.IngredienteEnAlimento
                        .Where(iea => iea.AlimentoId == alimento.Id)
                        .Join(_context.Ingrediente,
                        iea => iea.IngredienteId,
                        ing => ing.Id,
                        (iea, ing) => new IngredienteEnAlimentoOutput
                        {
                            Name = ing.Name,
                            QuantityPer = iea.QuantityPer,
                        }).ToList();

                    List<AditivoEnAlimentoOutput> aditivos = _context.AditivoEnAlimento
                        .Where(aea => aea.AlimentoId == alimento.Id)
                        .Join(_context.Aditivo,
                        aea => aea.AditivoId,
                        adi => adi.Id,
                        (aea, adi) => new AditivoEnAlimentoOutput
                        {
                            Name = adi.Name,
                            QuantityGra = aea.QuantityGra,
                            QuantityUI = aea.QuantityUI,
                        }).ToList();

                    List<AnaliticoEnAlimentoOutput> analiticos = _context.AnaliticoEnAlimento
                        .Where(aea => aea.AlimentoId == alimento.Id)
                        .Join(_context.Analitico,
                        aea => aea.AnaliticoId,
                        ana => ana.Id,
                        (aea, ana) => new AnaliticoEnAlimentoOutput
                        {
                            Name = ana.Name,
                            QuantityGra = aea.QuantityGra,
                            QuantityPer = aea.QuantityPer,
                        }).ToList();

                    alimento.Ingredientes = ingredientes;
                    alimento.Aditivos = aditivos;
                    alimento.Analiticos = analiticos;
                }


                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = alimentos;
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
        /// Se obtiene la información de un alimento ingresando su identificador.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <returns></returns>
        [HttpGet(RoutesPaths.ALIMENTO_BUSCAR)]
        public ActionResult<ApiResponse> ObtenerAlimento(int alimentoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                if (_context.Alimento.Where(ali => ali.Id == alimentoId).FirstOrDefault() == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }
                AlimentoOutput alimento = _context.Alimento
                    .Where(ali => ali.Id == alimentoId)
                    .Join(_context.Marca,
                    ali => ali.MarcaId,
                    mar => mar.Id,
                    (ali, mar) => new { ali, mar })
                    .Join(_context.Especie,
                    ali_mar => ali_mar.ali.EspecieId,
                    esp => esp.Id,
                    (ali_mar, esp) => new { ali_mar, esp })
                    .Join(_context.Etapa,
                    ali_mar_esp => ali_mar_esp.ali_mar.ali.EtapaId,
                    eta => eta.Id,
                    (ali_mar_esp, eta) => new AlimentoOutput
                    {
                        Id = ali_mar_esp.ali_mar.ali.Id,
                        Name = ali_mar_esp.ali_mar.ali.Name,
                        Size = ali_mar_esp.ali_mar.ali.Size,
                        Marca = ali_mar_esp.ali_mar.mar.Name,
                        Especie = ali_mar_esp.esp.Name,
                        Etapa = eta.Name,
                        LastUpdate = ali_mar_esp.ali_mar.ali.LastUpdate
                    }).FirstOrDefault();


                    List<IngredienteEnAlimentoOutput> ingredientes = _context.IngredienteEnAlimento
                    .Where(iea => iea.AlimentoId == alimento.Id)
                    .Join(_context.Ingrediente,
                    iea => iea.IngredienteId,
                    ing => ing.Id,
                    (iea, ing) => new IngredienteEnAlimentoOutput
                    {
                        Name = ing.Name,
                        QuantityPer = iea.QuantityPer,
                    }).ToList();

                    List<AditivoEnAlimentoOutput> aditivos = _context.AditivoEnAlimento
                    .Where(aea => aea.AlimentoId == alimento.Id)
                    .Join(_context.Aditivo,
                    aea => aea.AditivoId,
                    adi => adi.Id,
                    (aea, adi) => new AditivoEnAlimentoOutput
                    {
                        Name = adi.Name,
                        QuantityGra = aea.QuantityGra,
                        QuantityUI = aea.QuantityUI,
                    }).ToList();

                    List<AnaliticoEnAlimentoOutput> analiticos = _context.AnaliticoEnAlimento
                    .Where(aea => aea.AlimentoId == alimento.Id)
                    .Join(_context.Analitico,
                    aea => aea.AnaliticoId,
                    ana => ana.Id,
                    (aea, ana) => new AnaliticoEnAlimentoOutput
                    {
                        Name = ana.Name,
                        QuantityGra = aea.QuantityGra,
                        QuantityPer = aea.QuantityPer,
                    }).ToList();

                    alimento.Ingredientes = ingredientes;
                    alimento.Aditivos = aditivos;
                    alimento.Analiticos = analiticos;


                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = alimento;
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
        /// Se recibe la información de un alimento y se añade a la base de datos.
        /// </summary>
        /// <param name="alimento"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ALIMENTO_NUEVO)]
        public async Task<ActionResult<ApiResponse>> AgregarAlimento([FromBody] AlimentoInput alimento)
        {
            ApiResponse apiResponse = new();
            try
            {
                EMarca marca = _context.Marca.FirstOrDefault(mar => mar.Id == alimento.MarcaId);
                Especie especie = _context.Especie.FirstOrDefault(esp => esp.Id == alimento.EspecieId);
                Etapa etapa = _context.Etapa.FirstOrDefault(eta => eta.Id == alimento.EtapaId);

                if (marca == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }
                else if (especie == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }
                else if (etapa == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                EAlimento eAlimento = new()
                {
                    Name = alimento.Name,
                    Size = alimento.Size,
                    MarcaId = alimento.MarcaId,
                    EspecieId = alimento.EspecieId,
                    EtapaId = alimento.EtapaId,
                    LastUpdate = DateTime.UtcNow,
                    Marca = marca,
                    Especie = especie,
                    Etapa = etapa,
                };
                await _context.Alimento.AddAsync(eAlimento);
                await _context.SaveChangesAsync();

                AlimentoOutput alimentoOutput = new()
                {
                    Id = eAlimento.Id,
                    Name = eAlimento.Name,
                    Size = eAlimento.Size,
                    Marca = eAlimento.Marca.Name,
                    Especie = eAlimento.Especie.Name,
                    Etapa = eAlimento.Etapa.Name,
                    LastUpdate= eAlimento.LastUpdate,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = alimentoOutput;
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
        /// Se recibe el identificador de un alimento y la nueva informacion para actualizarlo.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <param name="alimento"></param>
        /// <returns></returns>
        [HttpPut(RoutesPaths.ALIMENTO_ACTUALIZAR)]
        public async Task<ActionResult<ApiResponse>> ActualizarAlimento(int alimentoId, [FromBody] AlimentoInput alimento)
        {
            ApiResponse apiResponse = new();
            try
            {
                EMarca marca = _context.Marca.FirstOrDefault(mar => mar.Id == alimento.MarcaId);
                Especie especie = _context.Especie.FirstOrDefault(esp => esp.Id == alimento.EspecieId);
                Etapa etapa = _context.Etapa.FirstOrDefault(eta => eta.Id == alimento.EtapaId);

                if (marca == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = MarcaMessages.MARCA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }
                else if (especie == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EspecieMessages.ESPECIE_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }
                else if (etapa == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = EtapaMessages.ETAPA_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                // Verificar que el alimento exista
                EAlimento eAlimento = _context.Alimento.FirstOrDefault(ali => ali.Id == alimentoId);
                if (eAlimento == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                eAlimento.Name = alimento.Name;
                eAlimento.Size = alimento.Size;
                eAlimento.MarcaId = alimento.MarcaId;
                eAlimento.EspecieId = alimento.EspecieId;
                eAlimento.EtapaId = alimento.EtapaId;
                eAlimento.Marca = marca;
                eAlimento.Especie = especie;
                eAlimento.Etapa = etapa;
                eAlimento.LastUpdate = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                AlimentoOutput alimentoOutput = new()
                {
                    Id = eAlimento.Id,
                    Name = eAlimento.Name,
                    Size = eAlimento.Size,
                    Marca = marca.Name,
                    Especie = especie.Name,
                    Etapa = etapa.Name,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = alimentoOutput;
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
        /// Se recibe el identificador de un alimento y este se elimina de la base de datos.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <returns></returns>
        [HttpDelete(RoutesPaths.ALIMENTO_ELIMINAR)]
        public async Task<ActionResult<ApiResponse>> EliminarAlimento(int alimentoId)
        {
            ApiResponse apiResponse = new();
            try
            {
                // Verificar que el ingrediente exista
                EAlimento eAlimento = _context.Alimento.FirstOrDefault(ali => ali.Id == alimentoId);
                if (eAlimento == null)
                {
                    apiResponse.Error = true;
                    apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                    apiResponse.Data = null;
                    return BadRequest(apiResponse);
                }

                _context.Remove(eAlimento);

                await _context.SaveChangesAsync();

                List<IngredienteEnAlimentoOutput> ingredientes = _context.IngredienteEnAlimento
                    .Where(iea => iea.AlimentoId == alimentoId)
                    .Join(_context.Ingrediente,
                    iea => iea.IngredienteId,
                    ing => ing.Id,
                    (iea, ing) => new IngredienteEnAlimentoOutput
                    {
                        Name = ing.Name,
                        QuantityPer = iea.QuantityPer,
                    }).ToList();

                List<AditivoEnAlimentoOutput> aditivos = _context.AditivoEnAlimento
                .Where(aea => aea.AlimentoId == alimentoId)
                .Join(_context.Aditivo,
                aea => aea.AditivoId,
                adi => adi.Id,
                (aea, adi) => new AditivoEnAlimentoOutput
                {
                    Name = adi.Name,
                    QuantityGra = aea.QuantityGra,
                    QuantityUI = aea.QuantityUI,
                }).ToList();

                List<AnaliticoEnAlimentoOutput> analiticos = _context.AnaliticoEnAlimento
                .Where(aea => aea.AlimentoId == alimentoId)
                .Join(_context.Analitico,
                aea => aea.AnaliticoId,
                ana => ana.Id,
                (aea, ana) => new AnaliticoEnAlimentoOutput
                {
                    Name = ana.Name,
                    QuantityGra = aea.QuantityGra,
                    QuantityPer = aea.QuantityPer,
                }).ToList();

                AlimentoOutput alimentoOutput = new()
                {
                    Id = eAlimento.Id,
                    Name = eAlimento.Name,
                    Size = eAlimento.Size,
                    Marca = eAlimento.Marca.Name,
                    Especie = eAlimento.Especie.Name,
                    Etapa = eAlimento.Etapa.Name,
                    Ingredientes = ingredientes,
                    Aditivos = aditivos,
                    Analiticos = analiticos,
                };

                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = alimentoOutput;
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
        /// Agrega una lista de ingredientes a un alimento.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <param name="ingredientesEnAlimento"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ALIMENTO_INGREDIENTES)]
        public async Task<ActionResult<ApiResponse>> AgregarIngredientesEnAlimento(int alimentoId, [FromBody] List<IngredienteEnAlimentoInput> ingredientesEnAlimento)
        {
            ApiResponse apiResponse = new();
            List <ApiResponse> subApiResponses = new();
            try
            {
                foreach (IngredienteEnAlimentoInput ingredienteEnAlimento in ingredientesEnAlimento)
                {
                    ApiResponse subApiResponse = new();

                    // Verificar si existe alimento e ingrediente con los identificadores ingresados
                    EAlimento alimento = _context.Alimento.FirstOrDefault(ali => ali.Id == alimentoId);
                    EIngrediente ingrediente = _context.Ingrediente.FirstOrDefault(ing => ing.Id == ingredienteEnAlimento.IngredienteId);
                    if (alimento == null)
                    {
                        apiResponse.Error = true;
                        apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                        apiResponse.Data = null;
                        return BadRequest(apiResponse);
                    }
                    else if (ingrediente == null)
                    {
                        subApiResponse.Error = true;
                        subApiResponse.Message = IngredienteMessages.INGREDIENTE_NOT_FOUND;
                        subApiResponse.Data = ingredienteEnAlimento;
                        subApiResponses.Add(subApiResponse);
                    }
                    else
                    {
                        EIngredienteEnAlimento eIngredienteEnAlimento = new()
                        {
                            IngredienteId = ingredienteEnAlimento.IngredienteId,
                            AlimentoId = alimentoId,
                            QuantityPer = ingredienteEnAlimento.QuantityPer,
                            Ingrediente = ingrediente,
                            Alimento = alimento
                        };
                        // Revisar si el ingrediente ya existe en el alimento
                        var ingredienteExistente = _context.IngredienteEnAlimento.FirstOrDefault(ing =>
                        ing.AlimentoId == alimentoId &&
                        ing.IngredienteId == ingredienteEnAlimento.IngredienteId);
                        if (ingredienteExistente == null)
                        {
                            subApiResponse.Error = false;
                            subApiResponse.Message = Messages.SUCCESS_RESPONSE;
                            subApiResponse.Data = ingredienteEnAlimento;
                            subApiResponses.Add(subApiResponse);
                            await _context.IngredienteEnAlimento.AddAsync(eIngredienteEnAlimento);
                        }
                        else
                        {
                            subApiResponse.Error = true;
                            subApiResponse.Message = IngredienteMessages.INGREDIENTE_EXISTENTE;
                            subApiResponse.Data = ingredienteEnAlimento;
                            subApiResponses.Add(subApiResponse);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = subApiResponses;
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
        /// Agrega una lista de aditivos a un alimento.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <param name="aditivosEnAlimento"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ALIMENTO_ADITIVOS)]
        public async Task<ActionResult<ApiResponse>> AgregarAditivosEnAlimento(int alimentoId, [FromBody] List<AditivoEnAlimentoInput> aditivosEnAlimento)
        {
            ApiResponse apiResponse = new();
            List<ApiResponse> subApiResponses = new();
            try
            {
                foreach (AditivoEnAlimentoInput aditivoEnAlimento in aditivosEnAlimento)
                {
                    ApiResponse subApiResponse = new();

                    // Verificar si existe alimento e ingrediente con los identificadores ingresados
                    EAlimento alimento = _context.Alimento.FirstOrDefault(ali => ali.Id == alimentoId);
                    EAditivo aditivo = _context.Aditivo.FirstOrDefault(adi => adi.Id == aditivoEnAlimento.AditivoId);
                    if (alimento == null)
                    {
                        apiResponse.Error = true;
                        apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                        apiResponse.Data = null;
                        return BadRequest(apiResponse);
                    }
                    else if (aditivo == null)
                    {
                        subApiResponse.Error = true;
                        subApiResponse.Message = AditivoMessages.ADITIVO_NOT_FOUND;
                        subApiResponse.Data = aditivoEnAlimento;
                        subApiResponses.Add(subApiResponse);
                    }
                    else
                    {
                        EAditivoEnAlimento eAditivoEnAlimento = new()
                        {
                            AditivoId = aditivoEnAlimento.AditivoId,
                            AlimentoId = alimentoId,
                            QuantityUI = aditivoEnAlimento.QuantityUI,
                            QuantityGra = aditivoEnAlimento.QuantityGra,
                            Aditivo = aditivo,
                            Alimento = alimento
                        };
                        // Revisar si el ingrediente ya existe en el alimento
                        var aditivoExistente = _context.AditivoEnAlimento.FirstOrDefault(adi =>
                        adi.AlimentoId == alimentoId &&
                        adi.AditivoId == aditivoEnAlimento.AditivoId);
                        if (aditivoExistente == null)
                        {
                            subApiResponse.Error = false;
                            subApiResponse.Message = Messages.SUCCESS_RESPONSE;
                            subApiResponse.Data = aditivoEnAlimento;
                            subApiResponses.Add(subApiResponse);
                            await _context.AditivoEnAlimento.AddAsync(eAditivoEnAlimento);
                        }
                        else
                        {
                            subApiResponse.Error = true;
                            subApiResponse.Message = AditivoMessages.ADITIVO_EXISTENTE;
                            subApiResponse.Data = aditivoEnAlimento;
                            subApiResponses.Add(subApiResponse);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = subApiResponses;
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
        /// Agrega una lista de analiticos a un alimento.
        /// </summary>
        /// <param name="alimentoId"></param>
        /// <param name="analiticosEnAlimento"></param>
        /// <returns></returns>
        [HttpPost(RoutesPaths.ALIMENTO_ANALITICOS)]
        public async Task<ActionResult<ApiResponse>> AgregarAnaliticosEnAlimento(int alimentoId, [FromBody] List<AnaliticoEnAlimentoInput> analiticosEnAlimento)
        {
            ApiResponse apiResponse = new();
            List<ApiResponse> subApiResponses = new();
            try
            {
                foreach (AnaliticoEnAlimentoInput analiticoEnAlimento in analiticosEnAlimento)
                {
                    ApiResponse subApiResponse = new();

                    // Verificar si existe alimento e ingrediente con los identificadores ingresados
                    EAlimento alimento = _context.Alimento.FirstOrDefault(ali => ali.Id == alimentoId);
                    EAnalitico analitico = _context.Analitico.FirstOrDefault(ana => ana.Id == analiticoEnAlimento.AnaliticoId);
                    if (alimento == null)
                    {
                        apiResponse.Error = true;
                        apiResponse.Message = AlimentoMessages.ALIMENTO_NOT_FOUND;
                        apiResponse.Data = null;
                        return BadRequest(apiResponse);
                    }
                    else if (analitico == null)
                    {
                        subApiResponse.Error = true;
                        subApiResponse.Message = AnaliticoMessages.ANALITICO_NOT_FOUND;
                        subApiResponse.Data = analiticoEnAlimento;
                        subApiResponses.Add(subApiResponse);
                    }
                    else
                    {
                        EAnaliticoEnAlimento eAnaliticoEnAlimento = new()
                        {
                            AnaliticoId = analiticoEnAlimento.AnaliticoId,
                            AlimentoId = alimentoId,
                            QuantityPer = analiticoEnAlimento.QuantityPer,
                            QuantityGra = analiticoEnAlimento.QuantityGra,
                            Analitico = analitico,
                            Alimento = alimento
                        };
                        // Revisar si el ingrediente ya existe en el alimento
                        var analiticoExistente = _context.AnaliticoEnAlimento.FirstOrDefault(ana =>
                        ana.AlimentoId == alimentoId &&
                        ana.AnaliticoId == analiticoEnAlimento.AnaliticoId);
                        if (analiticoExistente == null)
                        {
                            subApiResponse.Error = false;
                            subApiResponse.Message = Messages.SUCCESS_RESPONSE;
                            subApiResponse.Data = analiticoEnAlimento;
                            subApiResponses.Add(subApiResponse);
                            await _context.AnaliticoEnAlimento.AddAsync(eAnaliticoEnAlimento);
                        }
                        else
                        {
                            subApiResponse.Error = true;
                            subApiResponse.Message = AnaliticoMessages.ANALITICO_EXISTENTE;
                            subApiResponse.Data = analiticoEnAlimento;
                            subApiResponses.Add(subApiResponse);
                        }
                    }
                }
                await _context.SaveChangesAsync();
                apiResponse.Error = false;
                apiResponse.Message = Messages.SUCCESS_RESPONSE;
                apiResponse.Data = subApiResponses;
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
