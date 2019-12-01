import { Component, OnInit } from '@angular/core';
import { UserService } from './../../shared/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registrration',
  templateUrl: './registrration.component.html',
  styles: []
})
export class RegistrrationComponent implements OnInit {

  constructor(public service: UserService , private toaster: ToastrService)
   {
     
    }

  ngOnInit() {
    this.service.formModel.reset
  }
  onSubmit(){
    this.service.register().subscribe
    (
      (res: any) =>{
        if(res.succeeded){
          this.service.formModel.reset()
          this.toaster.success('new user created!', 'Registration Success')
                }else{
                
          res.errors.forEach(element => {
            switch(element.code){
              case 'DuplicateUserName':
                this.toaster.error("User name  is already taken." , 'Registration failed.');
                break;
                default:
                    this.toaster.error(element.description , 'Registration failed.');
                  break;
            }
          });
          
        }
      },
      err=>{
        console.log(err);
      }
    );
  }

}
