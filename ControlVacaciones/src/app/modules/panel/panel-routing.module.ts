import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "@core/guards/auth.guard";
import { INTERNAL_PATHS, INTERNAL_ROUTES } from "@data/constants/routes";
import { HistoryComponent } from "./history/history.component";
import { RequestComponent } from "./request/request.component";
import { ResponseRequestComponent } from "./response-request/response-request.component";

const routes: Routes = [
    {
        path: INTERNAL_PATHS.PANEL_HISTORY,
        component: HistoryComponent,
        canActivate: [AuthGuard]
    },
    {
        path: INTERNAL_PATHS.PANEL_REQUESTS,
        component: RequestComponent,
        canActivate: [AuthGuard]
    },
    {
        path: INTERNAL_PATHS.PANEL_RESPONSES,
        component: ResponseRequestComponent,
        canActivate: [AuthGuard]
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
