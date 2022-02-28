export interface IFilterBarMenu {
    title: string,
    menus: {
        name: string,
        status: boolean,
        subMenus: {
            name: string,
            link: string,
        }[],
    }[],
}
