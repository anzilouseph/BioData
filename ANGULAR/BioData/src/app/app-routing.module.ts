import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginCompComponent } from './login-comp/login-comp.component';
import { GetAllUsersCompComponent } from './get-all-users-comp/get-all-users-comp.component';
import { AdminDashBoardComponent } from './admin-dash-board/admin-dash-board.component';
import { AdminGetByIdCompComponent } from './admin-get-by-id-comp/admin-get-by-id-comp.component';
import { UserDashBoardComponent } from './user-dash-board/user-dash-board.component';

const routes: Routes = [
  {path:"",component:LoginCompComponent},
  {path:"adminDashBoard",component:AdminDashBoardComponent},
  {path:"getAllUser",component:GetAllUsersCompComponent},
  {path:"getUserByAdmin/:id",component:AdminGetByIdCompComponent},
  {path:"userDashBoard",component:UserDashBoardComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
