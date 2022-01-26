import { environment as ENV } from "@env/environment"

export const API_ROUTES = {
    AUTH: {
        LOGIN: `${ENV.backend}users`
    },
    PANEL: {
        REQUEST: `${ENV.backend}requests`
    }
}
