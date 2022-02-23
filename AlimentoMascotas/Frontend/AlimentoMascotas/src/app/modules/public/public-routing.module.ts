import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { INTERNAL_PATHS } from "@data/constants";
import { MainComponent } from "./main/main.component";

const routes: Routes = [
    { 
        path: INTERNAL_PATHS.PUBLIC_DEFAULT,
        component: MainComponent,
    },
    { 
        path: '**',
        redirectTo: '',
        pathMatch: 'full',
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PublicRouteModule { }
