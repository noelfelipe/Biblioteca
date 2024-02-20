import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Router } from '@angular/router'

@Injectable({
  providedIn: 'root'
})
export class WebApiService {

  constructor(private httpClient: HttpClient, private router: Router) {}

  get(url: string): Observable<any> {
    const httpOptions = this.getHttpOptions();

    return this.httpClient.get(url, httpOptions)
      .pipe(
        map((response: any) => this.ReturnResponseData(response)),
        catchError(this.handleError)
      );
  }

  post(url: string, model: any): Observable<any> {
    const httpOptions = this.getHttpOptions();

    return this.httpClient.post(url, model, httpOptions)
      .pipe(
        map((response: any) => {
          this.ReturnResponseData(response);
          this.navigateBack();
        }),
        catchError(this.handleError)
      );
  }

  update(url: string, model: any): Observable<any> {
    const httpOptions = this.getHttpOptions();

    return this.httpClient.put(url, model, httpOptions)
      .pipe(
        map((response: any) => {
          this.ReturnResponseData(response);
          this.navigateBack();
        }),
        catchError(this.handleError)
      );
  }

  delete(url: string): Observable<any> {
    const httpOptions = this.getHttpOptions();

    return this.httpClient.delete(url, httpOptions)
      .pipe(
        map((response: any) => {
          this.ReturnResponseData(response);
          this.refreshPage();
        }),
        catchError(this.handleError)
      );
  }

  private ReturnResponseData(response: any) {
    return response;
  }

  private handleError(error: any) {
    return throwError(error);
  }

  private getHttpOptions(): any {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      observe: "response" as 'body'
    };
  }

  private navigateBack(): void {
    this.router.navigate(['/Home']); // Navigate back to the home page
  }

  private refreshPage(): void {
    const currentRoute = this.router.url;
    this.router.navigateByUrl('/Home', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentRoute]); // Navigating back to the current route
    });
  }
}
