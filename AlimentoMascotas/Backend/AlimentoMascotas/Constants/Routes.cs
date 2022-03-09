namespace AlimentoMascotas.Constants
{
    public class RoutesPaths
    {
        // MAIN
        public const string MAIN = "api";

        // ALIMENTOS
        public const string MAIN_ALIMENTO = "alimento";
        public const string ALIMENTO_LISTAR = "listar";
        public const string ALIMENTO_BUSCAR = "buscar/{alimentoId}";
        public const string ALIMENTO_NUEVO = "nuevo";
        public const string ALIMENTO_ACTUALIZAR = "actualizar/{alimentoId}";
        public const string ALIMENTO_ELIMINAR = "eliminar/{alimentoId}";
        public const string ALIMENTO_INGREDIENTES = "agregar-ingredientes/{alimentoId}";
        public const string ALIMENTO_ADITIVOS = "agregar-aditivos/{alimentoId}";
        public const string ALIMENTO_ANALITICOS = "agregar-analiticos/{alimentoId}";

        //SIZES
        public const string MAIN_SIZE = "sizes";
        public const string SIZE_LISTAR = "listar";
        public const string SIZE_BUSCAR = "buscar/{sizeId}";
        public const string SIZE_NUEVO = "nuevo";
        public const string SIZE_ACTUALIZAR = "actualizar/{sizeId}";
        public const string SIZE_ELIMINAR = "eliminar/{sizeId}";

        // INGREDIENTES
        public const string MAIN_INGREDIENTE = "ingrediente";
        public const string INGREDIENTE_LISTAR = "listar";
        public const string INGREDIENTE_BUSCAR = "buscar/{ingredienteId}";
        public const string INGREDIENTE_NUEVO = "nuevo";
        public const string INGREDIENTE_ACTUALIZAR = "actualizar/{ingredienteId}";
        public const string INGREDIENTE_ELIMINAR = "eliminar/{ingredienteId}";

        // ADITIVOS
        public const string MAIN_ADITIVO = "aditivo";
        public const string ADITIVO_LISTAR = "listar";
        public const string ADITIVO_BUSCAR = "buscar/{aditivoId}";
        public const string ADITIVO_NUEVO = "nuevo";
        public const string ADITIVO_ACTUALIZAR = "actualizar/{aditivoId}";
        public const string ADITIVO_ELIMINAR = "eliminar/{aditivoId}";

        // ANALITICOS
        public const string MAIN_ANALITICO = "analitico";
        public const string ANALITICO_LISTAR = "listar";
        public const string ANALITICO_BUSCAR = "buscar/{analiticoId}";
        public const string ANALITICO_NUEVO = "nuevo";
        public const string ANALITICO_ACTUALIZAR = "actualizar/{analiticoId}";
        public const string ANALITICO_ELIMINAR = "eliminar/{analiticoId}";

        // ESPECIES
        public const string MAIN_ESPECIE = "especie";
        public const string ESPECIE_LISTAR = "listar";
        public const string ESPECIE_BUSCAR = "buscar/{especieId}";
        public const string ESPECIE_NUEVA = "nueva";
        public const string ESPECIE_ACTUALIZAR = "actualizar/{especieId}";
        public const string ESPECIE_ELIMINAR = "eliminar/{especieId}";

        // ETAPAS
        public const string MAIN_ETAPA = "etapa";
        public const string ETAPA_LISTAR = "listar";
        public const string ETAPA_BUSCAR = "buscar/{etapaId}";
        public const string ETAPA_NUEVA = "nueva";
        public const string ETAPA_ACTUALIZAR = "actualizar/{etapaId}";
        public const string ETAPA_ELIMINAR = "eliminar/{etapaId}";

        // MARCAS
        public const string MAIN_MARCA = "marca";
        public const string MARCA_LISTAR = "listar";
        public const string MARCA_BUSCAR = "buscar/{marcaId}";
        public const string MARCA_NUEVA = "nueva";
        public const string MARCA_ACTUALIZAR = "actualizar/{marcaId}";
        public const string MARCA_ELIMINAR = "eliminar/{marcaId}";
    }

    public class InternalRoutes
    {
        public const string ALIMENTO = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_ALIMENTO;
        public const string SIZE = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_SIZE;
        public const string INGREDIENTE = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_INGREDIENTE;
        public const string ADITIVO = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_ADITIVO;
        public const string ANALITICO = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_ANALITICO;
        public const string ESPECIE = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_ESPECIE;
        public const string ETAPA = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_ETAPA;
        public const string MARCA = RoutesPaths.MAIN + "/" + RoutesPaths.MAIN_MARCA;
    }
}
