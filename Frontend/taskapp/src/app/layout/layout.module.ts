import { NavbarComponent } from './navbar/navbar.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { TranslateModule } from '@ngx-translate/core';
import { TranslateLoaderConfig } from '../core/helper/translateLoaderConfig';



@NgModule({
  declarations: [NavbarComponent],
  imports: [
    CommonModule,
    RouterModule,
    TranslateModule.forRoot(TranslateLoaderConfig.getTranslateLoaderConfig()),
  ],
  exports: [NavbarComponent]
})
export class LayoutModule { }
