import { Component } from '@angular/core';
import { BioDataServiceService } from '../BioDataService.service';
import { FormControl,FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-comp',
  templateUrl: './login-comp.component.html',
  styleUrls: ['./login-comp.component.css']
})
export class LoginCompComponent {

constructor(private service:BioDataServiceService,private router:Router){}

  loginForm = new FormGroup(
    {
      "emailOfUser" : new FormControl("",[Validators.required,Validators.pattern("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$")]),
      "passwordOfUser" : new FormControl("",Validators.required),
    }
  );

loginFormData:any  // to store the value of the form
data:any;
errorMessage:any;

Login()
  {
    if(this.loginForm.valid)
    {
      this.loginFormData=this.loginForm.value;
      this.service.login(this.loginFormData).subscribe({
        next:(res:any)=>
        {
          if(res.status)
          {
            this.data = res.data;
            
            console.log(res);
            localStorage.setItem("accessToken",res.data) // here we are keeping the token (which is in the "data:token") in a variable called "acessToken" later we retrive it, that code is added in the service.         
            
            //nammak eppo oru toiken kitty eni ee token veych nammalk "getbyIdOfUser" (which doesnt have an argument) vilikanam cuz ee token il role illa appo token ile id vecyh aa user ine eduth aa user inte role eduthitt eth admin aano user aano enn check cheythitt veenam eeth admin dashboard ilott aano atho user dashboard iltt aano poovande enn theerumanikeendathh
            this.service.getOwnProfile().subscribe(
              {
                next:(res1:any)=>  //res already used aayond just res1 nu koduthu enne ollu
                {
                  if(res1.status)
                  {
                    if(res1.data.roleOfUser==='Admin')
                    {
                      console.log(res1);
                       this.router.navigate(["/adminDashBoard"],{state : {admin:res1.data}}) // here if credntials is correct and if its Admin it will take to Admin Dash board and  the data of admin is also given to Admin dashboard component
                    }
                    else
                    {
                      console.log(res1);
                      this.router.navigate(['/userDashBoard'],{state:{user:res1.data}}) //if  the login person is a user it will redirect to the users dashboard
                    }
                  }
                  else
                  {
                    this.errorMessage=res1.message;
                  }
                },
                error:error=>
                {
                  this.errorMessage=error.message;
                }
              } // inner calling for getOwnProfile Ends


            );
          
          }
          else
          {
            alert(res.message);
            console.log(res);          
          }
        },
        error:error=>
        {
          alert(error.message);
        }
      });
    }
    else
    {
      alert("Invalid Format")
    }  
  }

  resetForm()
    {
      this.loginForm.reset();
    }

}
