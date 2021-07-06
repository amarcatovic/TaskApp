import { RegisterComponent } from './register/register.component';
import { ProfileComponent } from './profile/profile.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { TranslateLoaderConfig } from '../core/helper/translateLoaderConfig';
import { MaterialModule } from '../material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';



@NgModule({
  declarations: [ProfileComponent, RegisterComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    TranslateModule.forRoot(TranslateLoaderConfig.getTranslateLoaderConfig()),
    MaterialModule,
  ]
})
export class UsersModule { }
