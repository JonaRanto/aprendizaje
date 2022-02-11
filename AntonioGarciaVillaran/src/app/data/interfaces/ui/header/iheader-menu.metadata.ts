export interface IHeaderMenu {
    name: string,
    link: string,
    target: string,
    subMenus?: {
        name: string,
        link: string,
        target: string
    }[],
}
