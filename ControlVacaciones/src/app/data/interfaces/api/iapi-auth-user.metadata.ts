import { ROLES_ENUM } from "@data/enum";

export interface IApiUserAuthenticate {
    id: number;
    name: string;
    email: string;
    pass: string;
    role: ROLES_ENUM;
}
