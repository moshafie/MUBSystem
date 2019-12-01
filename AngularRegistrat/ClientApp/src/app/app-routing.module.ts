import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Route } from '@angular/compiler/src/core';
import {Routes, RouterModule} from '@angular/router';
import {UserComponent} from './user/user.component';
import {RegistrrationComponent} from './user/registrration/registrration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { EditeComponent } from './home/edite/edite.component';
import { AuthGuard } from './auth/auth.guard';

const routes:Routes=[
  {path:'',redirectTo:'/user/Login',pathMatch:'full'},
  {
    path:'user',component:UserComponent,
    children:[
      {path:'registration', component: RegistrrationComponent},
      {path:'Login', component: LoginComponent}
    ]
  },
  {path:'home', component:HomeComponent,canActivate:[AuthGuard]},
  {path:'Edite', component:EditeComponent}  
]

@NgModule({
  declarations: [],
  imports: [ RouterModule.forRoot(routes)  ],
exports:[RouterModule]
})
export class AppRoutingModule { }
