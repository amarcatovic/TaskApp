import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Injectable} from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {catchError, finalize, retry} from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';


@Injectable()
export class TaskAppHttpInterceptor implements HttpInterceptor {

  constructor(private toastr: ToastrService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    const token = localStorage.getItem('token');
    if (token) {
        req = req.clone({
            setHeaders: {
              Authorization: `Bearer ${token}`
            }
          });
    }

    return next.handle(req)
      .pipe(
        retry(2),

        catchError((error: HttpErrorResponse) => {
          this.toastr.error(`HTTP Error: ${req.url}`)
          return throwError(error);
        }),

        finalize(() => {
          const profilingMsg = `${req.method} "${req.urlWithParams}"`;
        })
        );
  }
}