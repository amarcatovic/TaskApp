import { MaterialModule } from './../material/material.module';
import { CreateTaskComponent } from './create-task/create-task.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditTaskComponent } from './edit-task/edit-task.component';
import { ViewTasksComponent } from './view-tasks/view-tasks.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateLoaderConfig } from '../core/helper/translateLoaderConfig';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
  declarations: [CreateTaskComponent, EditTaskComponent, ViewTasksComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    TranslateModule.forRoot(TranslateLoaderConfig.getTranslateLoaderConfig()),
    MaterialModule,
  ]
})

export class TasksModule { }
