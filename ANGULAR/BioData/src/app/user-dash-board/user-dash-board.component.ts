import { Component } from '@angular/core';
import { BioDataServiceService } from '../BioDataService.service';
import { FormControl,FormGroup,Validators } from '@angular/forms';
@Component({
  selector: 'app-user-dash-board',
  templateUrl: './user-dash-board.component.html',
  styleUrls: ['./user-dash-board.component.css']
})
export class UserDashBoardComponent {

  constructor (private service:BioDataServiceService){}

  data:any
  errorMessage:any;
  isEdit:boolean=false;

ngOnInit()
{
  this.data=history.state.user;
  this.populateForm();
}

  getForm=new FormGroup(
    {
      nameOfUser:new FormControl({value:"",disabled:true},[Validators.required, Validators.pattern("^[a-zA-Z ]+$")]),
      ageOfUser:new FormControl({value:"",disabled:true},[Validators.required,  Validators.pattern("^(1[01][0-9]|120|[1-9][0-9]?)$")]),
      addressOfUser:new FormControl({value:"",disabled:true}),
      emailOfUser:new FormControl({value:"",disabled:true},[Validators.required,  Validators.email,Validators.pattern('^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$')])
    
    });

    
  populateForm()
  {
    this.getForm.patchValue(
      {
        nameOfUser:this.data.nameOfUser,
        ageOfUser:this.data.ageOfUser,
        addressOfUser:this.data.addressOfUser,
        emailOfUser:this.data.emailOfUser,
      }
    )
  }

  edit()
  {
    this.isEdit=true;
    this.getForm.get('nameOfUser')?.enable();
    this.getForm.get('ageOfUser')?.enable();
    this.getForm.get('addressOfUser')?.enable();
    this.getForm.get('emailOfUser')?.enable();

  }

  updateData:any;
  submit()
  {
    if(this.getForm.valid)
    {
      this.updateData=this.getForm.value;
      this.service.updateProfile(this.updateData).subscribe({
        next:(res:any)=>
        {
          if(res.status)
          {
            alert(res.message)
            this.isEdit=false;
            this.getForm.disable();
            this.data=
            {
              nameOfUser:this.updateData.nameOfUser,
              ageOfUser: this.updateData.ageOfUser,
              addressOfUser: this.updateData.addressOfUser,
              emailOfUser: this.updateData.emailOfUser,
            };
            console.log(res);
            
          }
          else{
            this.errorMessage=res.message;
          }
        },
        error:error=>
        {
          this.errorMessage = error.message;
        }
      });
    }
    else
    {
      alert("Invalid form format");
    }
  }

  clear()
  {
    this.populateForm();
  }

  goback()
  {
    this.isEdit=false;
    this.getForm.disable();
  }



    



}
