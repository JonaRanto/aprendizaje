export interface IFilterBarMenu {
    title: string,
    menus: {
        name: string,
        status: boolean,
        subMenus: {
            id: number,
            name: string,
        }[],
    }[],
}
