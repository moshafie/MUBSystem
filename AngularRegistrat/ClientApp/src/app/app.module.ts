import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {ReactiveFormsModule,FormsModule} from '@angular/forms'
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrrationComponent } from './user/registrration/registrration.component';
import { AppRoutingModule } from './app-routing.module';
import { from } from 'rxjs';
import {HttpClientModule, HTTP_INTERCEPTORS} from "@angular/common/http";
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Authinterceptor } from './auth/auth.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { NewpostComponent } from './home/newpost/newpost.component';
import {NgxPaginationModule} from 'ngx-pagination';
import { EditeComponent } from './home/edite/edite.component';
import {
  MatButtonModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule,MatFormFieldModule,
  MatInputModule,
  MatRippleModule,
  MatDialogModule
} from '@angular/material';
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrrationComponent,
    LoginComponent,
    HomeComponent,
    NewpostComponent,
    EditeComponent,
    
  ],
  imports: [

  BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    NgxPaginationModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatRippleModule,
    MatMenuModule,
    MatToolbarModule,
    MatIconModule,
    MatCardModule,
    MatDialogModule

  ],
  providers: [UserService,{
    provide:HTTP_INTERCEPTORS,
    useClass:Authinterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
