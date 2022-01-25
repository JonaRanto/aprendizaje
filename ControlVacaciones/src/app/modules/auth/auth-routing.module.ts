import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { INTERNAL_PATHS, INTERNAL_ROUTES } from "@data/constants/routes";
import { LoginComponent } from "./login/login.component";

const routes: Routes = [
    {
        path: INTERNAL_PATHS.AUTH_LOGIN,
        component: LoginComponent
    },
    {
        path: '**',
        redirectTo: INTERNAL_ROUTES.AUTH_LOGIN,
        pathMatch: 'full'
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class AuthRoutingModule { }
