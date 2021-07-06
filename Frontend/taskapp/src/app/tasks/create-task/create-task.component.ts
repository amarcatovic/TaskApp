import { TasksService } from '../../core/services/tasks.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersService } from '../../core/services/users.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  users: User[] = [];
  taskForm: FormGroup;
  formSubmited: boolean = false;

  constructor(
    private userService: UsersService,
    private fb: FormBuilder,
    private taskService: TasksService,
  ) { }

  ngOnInit(): void {
    this.userService.getAllUsers()
      .subscribe(users => this.users = users);

    this.taskForm = this.fb.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      userId: [JSON.parse(localStorage.getItem('user')).id],
      assigneeId: ['', [Validators.required]],
      startDate: ['', [Validators.required]],
      finishDate: ['', [Validators.required]],
    });
  }

  createTask() {
    this.taskService.createTask(this.taskForm.value)
      .subscribe(_ => {
        this.formSubmited = true;
        this.taskService.onTaskCreated.next();
      });
  }
}
