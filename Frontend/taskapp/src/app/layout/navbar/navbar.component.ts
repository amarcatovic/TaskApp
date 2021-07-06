import { AuthService } from '../../core/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Language } from 'src/app/core/models/Language';
import { LanguagesService } from 'src/app/core/services/languages.service';
import { TranslationService } from 'src/app/core/services/translation.service';
import { User } from 'src/app/core/models/User';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  languages: Language[];
  currentLanguage: string;

  userLoggedIn: boolean = false;
  user: User;

  constructor(
    private translationService: TranslationService,
    private languagesService: LanguagesService,
    private authService: AuthService,
  ) { }

  ngOnInit(): void {
    this.languages = this.languagesService.getLanguages() || [];
    this.currentLanguage = this.translationService.getCurrentLanguage();
    this.translationService.onLanguageChange.subscribe((language:string) => {
      this.currentLanguage = language;
    });

    this.user = JSON.parse(localStorage.getItem('user'));

    if (this.user) {
      this.userLoggedIn = true;
    }

    this.authService.userLoggedIn
      .subscribe(value => {
        this.userLoggedIn = value;
        this.user = JSON.parse(localStorage.getItem('user'));
      });
  }

  changeLanguage(abbreviation: string): void {
    this.translationService.changeLanguage(abbreviation);
  }

}
