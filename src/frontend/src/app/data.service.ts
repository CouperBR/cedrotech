import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private REST_API_SERVER = "https://localhost:44324/api/";

  constructor(private httpClient: HttpClient) { }

  public sendGetRequest(typemodel, nome = ""){
    const params = new HttpParams()
    .set('nome', nome)
    return this.httpClient.get(this.REST_API_SERVER + typemodel, {params: params});
  }

  public sendGetByIdRequest(typemodel, id){
    return this.httpClient.get(this.REST_API_SERVER + typemodel + '/' + id);
  }


  public sendPostRequest(typemodel, data){
    const headers = {"content-type" : "application/json"};
    const body = data;
    const params = new HttpParams()
    .set('data', data)
    return this.httpClient.post(this.REST_API_SERVER + typemodel, body, {'headers': headers, params: params});
  }

  public sendPutRequest(typemodel, id, data){
    const headers = {"content-type" : "application/json"};
    const body = data;
    const params = new HttpParams()
    .set('data', data)
    return this.httpClient.put(this.REST_API_SERVER + typemodel + '/' + id, body, {'headers': headers, params: params});
  }

  public sendDeleteRequest(typemodel, id){
    const params = new HttpParams()
    .set('id', id)
    return this.httpClient.delete(this.REST_API_SERVER + typemodel, {params: params});
  }

}
