import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/shared/user.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formModel ={
    UserName:'',
    Password:''
  }
  constructor(private serviec:UserService ,private router: Router,private toastr: ToastrService) { }

  ngOnInit() {
    if(localStorage.getItem('token') != null){
      this.router.navigateByUrl('/home');
    }
  }

  onsubmit(form:NgForm){

    this.serviec.Login(form.value).subscribe(
      (res:any)=>{
        localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/home');
      },
      err=>{
        if(err.status==400){
            this.toastr.error('Incorrect username or password.', 'Authentication failed');
        }
        else
        console.log(err)
      }
    )
  }

}
