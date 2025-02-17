import { Component } from '@angular/core';
import { BioDataServiceService } from '../BioDataService.service';
import { FormsModule,FormControl,Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-admin-get-by-id-comp',
  templateUrl: './admin-get-by-id-comp.component.html',
  styleUrls: ['./admin-get-by-id-comp.component.css']
})
export class AdminGetByIdCompComponent {
  constructor(private service:BioDataServiceService,private router:Router,private route:ActivatedRoute){}

  getForm = new FormGroup(
    {
      nameOfUser: new FormControl({value:"",disabled:true}),
      ageOfUser: new FormControl({value:"",disabled:true}),
      addressOfUser: new FormControl({value:"",disabled:true}),
      emailOfUser: new FormControl({value:"",disabled:true}),
      roleOfUser: new FormControl({value:"",disabled:true}),
    }
  )

  id:any;
  data:any;
  errorMessage:any;


  ngOnInit()
  {
   this.getUserByAdmin()
  }

  getUserByAdmin()
  {
    this.id = this.route.snapshot.params["id"];
    this.service.getByIdForAdmin(this.id).subscribe(
      {
        next:(res:any)=>
        {
          if(res.status)
          {
            this.data=res.data;
            console.log(res);
            this.populateForm();
          }
          else{
            this.errorMessage=res.message;
            console.log(res);
            
          }
        },
        error:error=>
        {
          this.errorMessage=error.message;
        }
      });  
  }



  
  populateForm()
  {
    this.getForm.patchValue(
      {
          nameOfUser:this.data.nameOfUser,
          ageOfUser:this.data.ageOfUser,
          addressOfUser:this.data.addressOfUser,
          emailOfUser:this.data.emailOfUser,
          roleOfUser:this.data.roleOfUser
      }
    );
    
  }
}
