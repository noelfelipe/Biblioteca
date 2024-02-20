import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebApiService } from '../webApi/web-api.service';

//var apiUrl = "https://localhost:44370/";

var apiUrl = "https://localhost:7065";

var httpLink = {
  getAllBook: apiUrl + "/api/Livros/",
  updateById: apiUrl + "/api/Livros/",
  deleteBookById: apiUrl + "/api/Livros/",
  getBookDetailById: apiUrl + "/api/Livros/",
  saveBook: apiUrl + "/api/Livros/"
}

@Injectable({
  providedIn: 'root'
})
export class HttpProviderService {

  constructor(private webApiService: WebApiService) { }

  public getAllBooks(): Observable<any> {
    return this.webApiService.get(httpLink.getAllBook);
  }

  public updateBook(model: any): Observable<any> {
    return this.webApiService.update(httpLink.updateById + model.Id, model);
  } 

  public deleteBookById(model: any): Observable<any> {
    return this.webApiService.delete(httpLink.deleteBookById + model);
  }

  public getBookDetailById(model: any): Observable<any> {
    return this.webApiService.get(httpLink.getBookDetailById + model);
  }

  public saveBook(model: any): Observable<any> {
    return this.webApiService.post(httpLink.saveBook, model);
  }
  
}
