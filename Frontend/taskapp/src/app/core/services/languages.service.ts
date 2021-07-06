import { Injectable } from '@angular/core';
import { Language } from 'src/app/core/models/Language';

@Injectable({
  providedIn: 'root'
})
export class LanguagesService {

  private languages: Language[] = [
    {
      id: 1,
      name: "ENGLISH_LANGUAGE",
      abbreviation: "en",
      iconPath: "assets/imgs/flags/en.svg"
    },
    {
      id: 2,
      name: "BOSNIAN_LANGUAGE",
      abbreviation: "ba",
      iconPath: "assets/imgs/flags/ba.svg"
    }
  ];

  constructor() { }

  getLanguages(): Language[] {
    return this.languages;
  }
}
