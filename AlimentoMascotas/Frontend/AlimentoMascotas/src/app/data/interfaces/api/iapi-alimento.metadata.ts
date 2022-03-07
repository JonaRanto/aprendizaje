import { IApiAditivo, IApiAnalitico, IApiIngrediente } from "..";

export interface IApiAlimento {
    id: string,
    name: string,
    size: number,
    especie: string,
    etapa: string,
    marca: string,
    ingredientes: IApiIngrediente[],
    aditivos: IApiAditivo[],
    analiticos: IApiAnalitico[],
}
