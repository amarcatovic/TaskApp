import { EditTaskService } from './../../core/services/edit-task.service';
import { EditTaskComponent } from './../edit-task/edit-task.component';
import { AppConstants } from './../../core/constants/app-constants.service';
import { TasksService } from '../../core/services/tasks.service';
import { Task } from '../../core/models/Task';
import { CreateTaskComponent } from './../../tasks/create-task/create-task.component';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-view-tasks',
  templateUrl: './view-tasks.component.html',
  styleUrls: ['./view-tasks.component.css']
})
export class ViewTasksComponent implements OnInit {

  tasks: Task[] = [];
  user: User;
  downloadTasksUrl: string;

  constructor(
    public dialog: MatDialog,
    private taskService: TasksService,
    private appConstants: AppConstants,
    private editTaskService: EditTaskService,
  ) { }

  ngOnInit(): void {
    this.downloadTasksUrl = this.appConstants.apiDownloadTasksRoute;
    this.user = JSON.parse(localStorage.getItem(this.appConstants.localStorageUser)) || {};

    this.taskService.onTaskCreated
      .subscribe(_ => {
        this.taskService.getLatestTasks()
          .subscribe(tasks => this.tasks = tasks);
      });

    this.taskService.getLatestTasks()
      .subscribe(tasks => this.tasks = tasks);
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(CreateTaskComponent, {
      width: '80%',
      height: '80vh'
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }

  openEditTaskDialog(task: Task): void {
    this.editTaskService.setTask(task);

    const dialogRef = this.dialog.open(EditTaskComponent, {
      width: '80%',
      height: '80vh'
    });

    dialogRef.afterClosed().subscribe(result => {
    });
  }
}
