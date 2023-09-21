
import { Cliente } from './../models/Cliente';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../models/Pagination';
//import { environment } from '@environments/environment';
//import { PaginatedResult } from '@app/models/Pagination';

@Injectable(
// { providedIn: 'root'}
)
export class ClienteService {
  baseURL = environment.apiURL + 'api/cliente';

  constructor(private http: HttpClient) { }

  public getClientes(page?: number, itemsPerPage?: number, term?: string): Observable<PaginatedResult<Cliente[]>> {
    const paginatedResult: PaginatedResult<Cliente[]> = new PaginatedResult<Cliente[]>();

    let params = new HttpParams;

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }

    if (term != null && term != '')
      params = params.append('term', term)

    return this.http
      .get<Cliente[]>(`${this.baseURL}/GetAll`, {observe: 'response', params })
      .pipe(
        take(1),
        map((response) => {
          paginatedResult.result = response.body;
          if(response.headers.has('Pagination')) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        }));
  }

  public getClienteById(id: number): Observable<Cliente> {
    return this.http
      .get<Cliente>(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  public post(cliente: Cliente): Observable<Cliente> {
    return this.http
      .post<Cliente>(this.baseURL, cliente)
      .pipe(take(1));
  }

  public put(cliente: Cliente): Observable<Cliente> {
    return this.http
      .put<Cliente>(`${this.baseURL}/${cliente.id}`, cliente)
      .pipe(take(1));
  }

  public deleteCliente(id: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }

  postUpload(clienteId: number, file: File): Observable<Cliente> {
    const fileToUpload = file[0] as File;
    const formData = new FormData();
    formData.append('file', fileToUpload);

    return this.http
      .post<Cliente>(`${this.baseURL}/upload-image/${clienteId}`, formData)
      .pipe(take(1));
  }
}


// import { HttpClient } from '@angular/common/http';
// import { Injectable } from '@angular/core';
// import { Observable } from 'rxjs';
// import { Cliente } from '../models/Cliente';

// @Injectable()
// export class ClienteService {

//   baseURL = 'https://localhost:7208/api/Cliente';

//   constructor(private http: HttpClient) { }

//   getTodosClientes(): Observable<Cliente[]>{
//     return this.http.get<Cliente[]>(`${this.baseURL}/GetAll`);
//   }

//   getClienteById(id: number): Observable<Cliente>{
//     return this.http.get<Cliente>(`${this.baseURL}/${id}`);
//   }

//   getClienteByNome(nome: string): Observable<Cliente>{
//     return this.http.get<Cliente>(`${this.baseURL}/${nome}`);
//   }

//   public post(cliente: Cliente): Observable<Cliente>{
//     return this.http.post<Cliente>(this.baseURL, cliente);
//   }

//   public put(id: number, cliente: Cliente): Observable<Cliente>{
//     return this.http.post<Cliente>(`${this.baseURL}/${id}`, cliente);
//   }

//   public delete(id: number): Observable<any>{
//     return this.http.delete(`${this.baseURL}/${id}`);
//   }



// }


