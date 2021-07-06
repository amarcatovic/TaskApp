import { AuthService } from '../../core/services/auth.service';
import { TasksService } from '../../core/services/tasks.service';
import { Task } from '../../core/models/Task';
import { User } from '../../core/models/User';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: User;
  userCreatedTasks: Task[] = [];
  userAssignedTasks: Task[] = [];

  constructor(
    private taskService: TasksService,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.user = JSON.parse(localStorage.getItem('user'));

    this.taskService.getUserCreatedTasks(this.user.id)
      .subscribe(response => {
        this.userCreatedTasks = response;
      });

    this.taskService.getUserAssignedTasks(this.user.id)
      .subscribe(response => {
        this.userAssignedTasks = response;
      });
  }

  logOff() {
    this.authService.logOff();
  }
}
