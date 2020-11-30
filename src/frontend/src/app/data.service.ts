import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private REST_API_SERVER = "https://localhost:44324/api/";

  constructor(private httpClient: HttpClient) { }

  handleError(error){
    if(error.error && error.error.errors){
      let len = Object.keys(error.error.errors).length;
      for (let index = 0; index < len; index++) {
        Object.values<Array<Object>>(error.error.errors)[index].forEach(element => {
          alert(element);
        });
      }
    }
    else{
      alert(error.message);
    }
    return throwError(error.message || "Server Error");
  }

  public sendGetRequest(typemodel, nome = ""){
    const params = new HttpParams()
    .set('nome', nome)
    return this.httpClient.get(this.REST_API_SERVER + typemodel, {params: params})
        .pipe(catchError(this.handleError));
  }

  public sendGetByIdRequest(typemodel, id){
    return this.httpClient.get(this.REST_API_SERVER + typemodel + '/' + id)
    .pipe(catchError(this.handleError));
  }


  public sendPostRequest(typemodel, data){
    const headers = {"content-type" : "application/json"};
    const body = data;
    const params = new HttpParams()
    .set('data', data)
    return this.httpClient.post(this.REST_API_SERVER + typemodel, body, {'headers': headers, params: params})
    .pipe(catchError(this.handleError));
  }

  public sendPutRequest(typemodel, id, data){
    const headers = {"content-type" : "application/json"};
    const body = data;
    const params = new HttpParams()
    .set('data', data)
    return this.httpClient.put(this.REST_API_SERVER + typemodel + '/' + id, body, {'headers': headers, params: params})
    .pipe(catchError(this.handleError));
  }

  public sendDeleteRequest(typemodel, id){
    const params = new HttpParams()
    .set('id', id)
    return this.httpClient.delete(this.REST_API_SERVER + typemodel, {params: params})
    .pipe(catchError(this.handleError));
  }

  public sendGetBuscaCepRequest(Cep){
    const params = new HttpParams()
    .set('Cep', Cep)
    return this.httpClient.get(this.REST_API_SERVER + "Endereco/", {params: params})
        .pipe(catchError(this.handleError));
  }

}
