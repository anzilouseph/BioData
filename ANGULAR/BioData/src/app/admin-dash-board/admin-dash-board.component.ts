import { Component } from '@angular/core';
import { BioDataServiceService } from '../BioDataService.service';
@Component({
  selector: 'app-admin-dash-board',
  templateUrl: './admin-dash-board.component.html',
  styleUrls: ['./admin-dash-board.component.css']
})
export class AdminDashBoardComponent {

  constructor(private service:BioDataServiceService){}

  adminData:any
  ngOnInit()
  {
    this.adminData=history.state.admin;
    console.log("adminDetails",this.adminData);
    
  }

}
