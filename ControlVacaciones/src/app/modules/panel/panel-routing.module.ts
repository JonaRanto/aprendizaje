import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { INTERNAL_PATHS, INTERNAL_ROUTES } from "@data/constants/routes";
import { HistoryComponent } from "./history/history.component";
import { RequestComponent } from "./request/request.component";

const routes: Routes = [
    {
        path: INTERNAL_PATHS.PANEL_HISTORY,
        component: HistoryComponent
    },
    {
        path: INTERNAL_PATHS.PANEL_REQUESTS,
        component: RequestComponent
    },
    {
        path: '**',
        redirectTo: INTERNAL_ROUTES.AUTH_LOGIN,
        pathMatch: 'full'
      }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class PanelRoutingModule { }
