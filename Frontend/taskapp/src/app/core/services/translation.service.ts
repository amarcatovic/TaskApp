import { Injectable } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Subject } from 'rxjs/internal/Subject';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  private supportedLanguages = ['en', 'bs'];
  public onLanguageChange: Subject<string> = new Subject<string>();

  constructor(private translateService: TranslateService) {

    this.translateService.addLangs(this.supportedLanguages);
    const savedLanguage = localStorage.getItem('lang') || 'en';
    this.translateService.setDefaultLang(savedLanguage);

    this.translateService.use(savedLanguage);
  }

  changeLanguage(abbreviation: string): void {
    this.translateService.use(abbreviation);
    localStorage.setItem('lang', abbreviation);
    this.onLanguageChange.next(abbreviation);
  }

  getCurrentLanguage(): string {
    return localStorage.getItem('lang') || 'en';
  } 
}
