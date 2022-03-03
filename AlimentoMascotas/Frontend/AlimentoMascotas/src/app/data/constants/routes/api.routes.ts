import { environment } from 'environments/environment';

export const API_ROUTES_PATHS = {
    API: {
        DEFAULT: 'api',
        ESPECIE: {
            DEFAULT: 'especie',
        },
        ETAPA: {
            DEFAULT: 'etapa'
        },
        MARCA: {
            DEFAULT: 'marca'
        },
    }
}

export const API_INTERNAL_PATHS = {
    ESPECIE: `${API_ROUTES_PATHS.API.DEFAULT}/${API_ROUTES_PATHS.API.ESPECIE.DEFAULT}`,
    ETAPA: `${API_ROUTES_PATHS.API.DEFAULT}/${API_ROUTES_PATHS.API.ETAPA.DEFAULT}`,
    MARCA: `${API_ROUTES_PATHS.API.DEFAULT}/${API_ROUTES_PATHS.API.MARCA.DEFAULT}`,
}

export const API_ROUTES_ACTION = {
    LISTAR: 'listar',
}

export const API_INTERNAL_ROUTES = {
    ESPECIE: {
        LISTAR: `${environment.backend}/${API_INTERNAL_PATHS.ESPECIE}/${API_ROUTES_ACTION.LISTAR}`,
    },
    ETAPA: {
        LISTAR: `${environment.backend}/${API_INTERNAL_PATHS.ETAPA}/${API_ROUTES_ACTION.LISTAR}`,
    },
    MARCA: {
        LISTAR: `${environment.backend}/${API_INTERNAL_PATHS.MARCA}/${API_ROUTES_ACTION.LISTAR}`,
    },
}
