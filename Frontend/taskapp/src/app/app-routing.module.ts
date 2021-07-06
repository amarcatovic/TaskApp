import { ViewTasksComponent } from './tasks/view-tasks/view-tasks.component';
import { ProfileComponent } from './users/profile/profile.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './users/register/register.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: '**', component: ViewTasksComponent },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }
