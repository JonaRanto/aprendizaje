using AlimentoMascotas.Constants;
using AlimentoMascotas.Entities;
using AlimentoMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet(RoutesPaths.ESPECIE_LISTAR)]
        public ActionResult<ApiResponse> ObtenerEspecies()
        {
            return View();
        }
    }
}
