import { ISidebarMenu } from "@data/interfaces";
import { INTERNAL_ROUTES, RESOURCES_BY_ROLES } from "./routes";

export const SIDEBAR_MENUS: ISidebarMenu[] = [
    {
        title: 'Mi cuenta',
        links: [
            {
                name: 'Historial de solicitudes',
                link: INTERNAL_ROUTES.PANEL_HISTORY,
                roles: RESOURCES_BY_ROLES.PANEL_HISTORY
            },
            {
                name: 'Solicitar vacaciones',
                link: INTERNAL_ROUTES.PANEL_REQUESTS,
                roles: RESOURCES_BY_ROLES.PANEL_REQUESTS
            },
            {
                name: 'Responder solicitudes',
                link: INTERNAL_ROUTES.PANEL_RESPONSES,
                roles: RESOURCES_BY_ROLES.PANEL_RESPONSES
            }
        ]
    }
]
