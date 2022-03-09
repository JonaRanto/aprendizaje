import { IApiAditivo } from "./iapi-aditivo.metadata";
import { IApiAnalitico } from "./iapi-analitico.metadata";
import { IApiIngrediente } from "./iapi-ingrediente.metadata";
import { IApiSize } from "./iapi-size.metadata";

export interface IApiAlimento {
    id: string,
    name: string,
    especie: string,
    etapa: string,
    marca: string,
    sizes: IApiSize[],
    ingredientes: IApiIngrediente[],
    aditivos: IApiAditivo[],
    analiticos: IApiAnalitico[],
}
