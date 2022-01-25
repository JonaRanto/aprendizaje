export interface ISidebarMenu {
    title: string;
    links: {
        name: string;
        link?: string;
        method?: () => any;
    }[];
}
