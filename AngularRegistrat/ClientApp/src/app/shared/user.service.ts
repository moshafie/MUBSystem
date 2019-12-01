import { Injectable } from '@angular/core';
import { FormBuilder, Validators,FormGroup } from '@angular/forms';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import { Posts } from './Posts';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  formData:Posts;
  list :Posts[];
  constructor(private fb:FormBuilder,private http: HttpClient)
   {

   }
readonly BaseURL="https://localhost:44390/api";
   formModel =this.fb.group({
UserName:['',Validators.required],
Email:['',[Validators.required,Validators.email]],
FirstName:[''],
LastName:[''],
passwords: this.fb.group(
  {
    Password:['',[Validators.required,Validators.minLength(4)]],
   ConfirmPassword :['',Validators.required]
},{validator:this.comparePasswords})

  });
  comparePasswords(fb: FormGroup){
let confirmpassword=fb.get('ConfirmPassword');
if (confirmpassword.errors==null || 'passwordMismatch' in confirmpassword.errors)
{
  if(fb.get('Password').value!=confirmpassword.value)
    confirmpassword.setErrors({passwordMismatch: true});
    else
    confirmpassword.setErrors(null)
 
}
  }

  register(){
  
    var body={
      UserName:this.formModel.value.UserName,
      FirstName:this.formModel.value.FirstName,
      LastName:this.formModel.value.LastName,
      Email:this.formModel.value.Email,
      Password:this.formModel.value.passwords.Password,
      
    };
   return this.http.post(this.BaseURL+"/ApplicationUser/register",body)
  }

  Login(formData){

    return this.http.post(this.BaseURL+"/ApplicationUser/Login",formData)
  }

  getUserProfile(){
   return this.http.get(this.BaseURL+'/UserProfile')
  }

  getPosts(){
    return this.http.get(this.BaseURL+"/PostModels")
    .toPromise().then(res=> this.list =res as Posts[])
  }

  addPost(formData : Posts){

    return this.http.post(this.BaseURL+"/PostModels/",formData)
  }
  DeletePost(id:number)
  {
       return this.http.delete(this.BaseURL+"/PostModels/"+id)
  }
  getById(id:Number){

    return this.http.get(this.BaseURL+"/PostModels/"+id)

  }
  putPost(formData: Posts){
    return this.http.put(this.BaseURL+"/PostModels/"+formData.id,formData)
  }
}
