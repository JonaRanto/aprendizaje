import { ROLES_ENUM } from "@data/enum";

export interface ISidebarMenu {
    title: string;
    links: {
        name: string;
        link?: string;
        method?: () => any;
        roles?: ROLES_ENUM[];
    }[];
}
