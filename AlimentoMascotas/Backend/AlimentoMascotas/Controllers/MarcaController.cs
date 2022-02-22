using AlimentoMascotas.Constants;
using AlimentoMascotas.Entities;
using AlimentoMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet(RoutesPaths.MARCA_LISTAR)]
        public ActionResult<ApiResponse> ObtenerMarcas()
        {
            return View();
        }
    }
}
