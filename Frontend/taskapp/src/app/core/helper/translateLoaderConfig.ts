import { HttpClient } from "@angular/common/http";
import { TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";

export class TranslateLoaderConfig {
    static getTranslateLoaderConfig(): object {
        return {
            loader: {
              provide: TranslateLoader,
              useFactory: (http: HttpClient) => { return new TranslateHttpLoader(http, './assets/i18n/', '.json'); },
              deps: [HttpClient]
            }
          }
    }
}