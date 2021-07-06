import { EditTaskService } from './../../core/services/edit-task.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TasksService } from 'src/app/core/services/tasks.service';
import { Task } from 'src/app/core/models/Task';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit {

  taskForm: FormGroup;
  formSubmited: boolean = false;

  task: Task;
  
  constructor(
    private fb: FormBuilder,
    private taskService: TasksService,
    private editTaskService: EditTaskService,
  ) { }

  ngOnInit(): void {
    this.task = this.editTaskService.getTask();
    this.popullateForm();
  }

  editTask() {
    this.taskService.editTask(this.task.id, this.taskForm.value)
      .subscribe(_ => {
        this.formSubmited = true;
        this.taskService.onTaskCreated.next();
      });
  }

  private popullateForm(): void {
    let taskTitle: string = '';
    let taskDescription: string = '';
    let taskStartDate: Date = new Date();
    let taskFinishDate: Date = new Date();

    if (this.task) {
      taskTitle = this.task.title;
      taskDescription = this.task.description;
      taskStartDate = this.task.startDate;
      taskFinishDate = this.task.finishDate;
    }

    this.taskForm = this.fb.group({
      title: [taskTitle, [Validators.required]],
      description: [taskDescription, [Validators.required]],
      startDate: [taskStartDate, [Validators.required]],
      finishDate: [taskFinishDate, [Validators.required]],
    });
  }
}
