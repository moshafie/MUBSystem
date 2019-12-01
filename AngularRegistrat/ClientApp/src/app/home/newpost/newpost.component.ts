import { Component, OnInit } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { NgForm } from '@angular/forms';
import { Posts } from './../../shared/Posts';

@Component({
  selector: 'app-newpost',
  templateUrl: './newpost.component.html',
  styleUrls: ['./newpost.component.css']
})
export class NewpostComponent implements OnInit {

 
  constructor(private service :UserService) { }

  ngOnInit() {
    this.resetForm();
  }

  onsubmit(form:NgForm){
         
   this.insertRecord(form);
   console.log(form.value)
   this.service.getPosts();
    
}

insertRecord(form:NgForm){
  this.service.addPost(form.value).subscribe(res =>{
    this.resetForm(form)
  })
}

resetForm(form?: NgForm){

  if(form != null)
  form.resetForm();
  this.service.formData={
    id:null,
    Title:'',
    body:'',
    Author:'',
    imageUrl:''
  }
}


}
