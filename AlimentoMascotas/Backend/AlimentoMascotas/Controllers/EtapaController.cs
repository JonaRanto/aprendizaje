using AlimentoMascotas.Constants;
using AlimentoMascotas.Entities;
using AlimentoMascotas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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

        [HttpGet(RoutesPaths.ETAPA_LISTAR)]
        public ActionResult<ApiResponse> ObtenerEtapas()
        {
            return View();
        }
    }
}
