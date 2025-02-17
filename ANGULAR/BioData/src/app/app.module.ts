import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginCompComponent } from './login-comp/login-comp.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { GetAllUsersCompComponent } from './get-all-users-comp/get-all-users-comp.component';
import { AdminDashBoardComponent } from './admin-dash-board/admin-dash-board.component';
import { AdminGetByIdCompComponent } from './admin-get-by-id-comp/admin-get-by-id-comp.component';
import { UserDashBoardComponent } from './user-dash-board/user-dash-board.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginCompComponent,
    GetAllUsersCompComponent,
    AdminDashBoardComponent,
    AdminGetByIdCompComponent,
    UserDashBoardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
