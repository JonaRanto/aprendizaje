import { environment } from "environments/environment";

export const ROUTES = {
    API: {
        ESPECIE: "api/especie",
    }
}

export const API_ROUTES = {
    ESPECIE: `${environment.backend}/${ROUTES.API.ESPECIE}`,
}
