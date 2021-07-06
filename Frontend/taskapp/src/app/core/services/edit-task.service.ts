import { Injectable } from '@angular/core';
import { Task } from '../models/Task';

@Injectable({
  providedIn: 'root'
})
export class EditTaskService {
  private task: Task = null;

  constructor() { }

  setTask(task: Task): void {
    this.task = task;
  }

  getTask(): Task {
    return this.task;
  }
}
