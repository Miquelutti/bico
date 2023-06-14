import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuard } from "src/app/core/helpers/auth.guard";
import { AboutComponent } from "../about/about.component";
import { HomeComponent } from "../home/home.component";
import { HowToWorkComponent } from "../how-to-work/how-to-work.component";
import { LandingpageComponent } from "../landingpage/landingpage.component";
import { LoginComponent } from "../login/login.component";
import { RegisterComponent } from "../register/register.component";

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'inicio'
    },
    {
        path: 'inicio',
        component: LandingpageComponent,
    },
    {
      path: 'como-funciona',
      component: HowToWorkComponent
    },
    {
      path: 'login',
      component: LoginComponent
    },
    {
      path: 'register',
      component: RegisterComponent
    },
    {
      path: 'home',
      component: HomeComponent,
      canActivate: [AuthGuard]
    },
    {
    path: '**',
    component: AboutComponent
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class HeaderRoutingModule { }
