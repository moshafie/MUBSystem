import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { NgForm } from '@angular/forms';
import { Posts } from '../shared/Posts';
import {MatDialog} from '@angular/material/dialog';
import { EditeComponent } from './edite/edite.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
 userDetails;
 Post;
 p: number = 1;
update;

  constructor( private router:Router,private service:UserService,public dialog: MatDialog) {
   }

  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
            this.userDetails =res;
      },
      err => {
        console.log(err)
      }
    );

    this.service.getPosts();

  }

  populatForm(mypost:Posts){
    this.service.formData =mypost;
    console.log("El Log",mypost)
  }
  
  onDelete(id:number)
{
  this.service.DeletePost(id).subscribe(rest=>{
    this.service.getPosts();
  })
}  
editePosts(id:Number){

  this.service.getById(id).subscribe(res=>{
    this.update = res
    console.log(this.update)
    if(this.update != null){
      this.service.formData=this.update
      this.router.navigateByUrl("/Edite")
    }
    console.log("FormData : ", this.service.formData)
  })
}
openDialog(id:number) {
  const dialogRef = this.dialog.open(EditeComponent);

  dialogRef.afterClosed().subscribe(result => {
    console.log(`Dialog result: ${result}`);
  });

  this.service.getById(id).subscribe(res=>{
    this.update = res
    console.log(this.update)
    if(this.update != null){
      this.service.formData=this.update
      this.router.navigateByUrl("/Edite")
    }
    console.log("FormData : ", this.service.formData)
  })
  
}

  onLogout(){

    localStorage.removeItem('token');
    this.router.navigate(['/user/Login']);
  }
}
