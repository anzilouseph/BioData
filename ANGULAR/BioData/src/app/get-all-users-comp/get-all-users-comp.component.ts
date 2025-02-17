import { Component } from '@angular/core';
import { BioDataServiceService } from '../BioDataService.service';
@Component({
  selector: 'app-get-all-users-comp',
  templateUrl: './get-all-users-comp.component.html',
  styleUrls: ['./get-all-users-comp.component.css']
})
export class GetAllUsersCompComponent {

  constructor (private service:BioDataServiceService){}

  data:any;
  errorMessage:any;
  

  ngOnInit()
  {
    this.getAllUsers();
  }
  getAllUsers()
  {
    this.service.getAllAdminOnly().subscribe({
      next:(res:any)=>
      {
        if(res.status)
        {
          this.data=res.data;
          console.log(res);
        }
        else
        {
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

}
