import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-edite',
  templateUrl: './edite.component.html',
  styleUrls: ['./edite.component.css']
})
export class EditeComponent implements OnInit {

  constructor( private router:Router,private service:UserService) { }

  ngOnInit() {
  }
updatePost(form: NgForm){
this.service.putPost(form.value).subscribe(res =>{
  this.service.getPosts();
});
this.router.navigateByUrl("/home")
}
}
