import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class BioDataServiceService {

  constructor(private Http:HttpClient) { }

  private getHeaders()
  {
    const token = localStorage.getItem('accessToken'); // to retrive the data we stored in the local storage from login.ts;
    return {
      headers:new HttpHeaders({
        'Authorization' : `Bearer ${token}`,
        'Content-Type' : 'application/json'
      })
    };
  }

  baseUrl = "https://localhost:7047/api/"


  //login
  login(data:any)
  {
    return this.Http.post(`${this.baseUrl}Authentication/Login`,data)
  }


//ADMIN ONLY FUNCTIONS

//getAll ForAdmin only , only admin can access this
getAllAdminOnly()
{
  return this.Http.get(`${this.baseUrl}AdminManagement/GetAll`,this.getHeaders())
}

//getByiD only Adin can acces it , it have a parameter cuz admin can guive id of any user as parameter and can have 
getByIdForAdmin(id:any)
{
  return this.Http.get(`${this.baseUrl}AdminManagement/GetById?users_id=${id}`,this.getHeaders());
}




//USERS ALSO FUNCTIONS


getOwnProfile()  // evde argument ella cuz ooro user intteeem profile aanu edukkan nookanee
{
  return this.Http.get(`${this.baseUrl}getOwnProfile`,this.getHeaders());
}

updateProfile(data:any)  //evde update the profile of the user by himself
{
  return this.Http.put(`${this.baseUrl}UpdateOwnProfile`,data,this.getHeaders());
}


}
