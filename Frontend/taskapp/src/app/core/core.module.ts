import { EditTaskService } from './services/edit-task.service';
import { TaskAppHttpInterceptor } from './interceptor/http-interceptor';
import { UsersService } from './services/users.service';
import { TranslationService } from './services/translation.service';
import { TasksService } from './services/tasks.service';
import { PhotosService } from './/services/photos.service';
import { LanguagesService } from './services/languages.service';
import { AuthService } from './services/auth.service';
import { NgModule } from '@angular/core';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HTTP_INTERCEPTORS, HttpInterceptor } from '@angular/common/http';
import { AppConstants } from './constants/app-constants.service';



@NgModule({
  imports: [
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    AuthService,
    LanguagesService,
    PhotosService,
    TasksService,
    TranslationService,
    UsersService,
    EditTaskService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TaskAppHttpInterceptor,
      multi: true
    },
    AppConstants,
  ]
})
export class CoreModule { }
