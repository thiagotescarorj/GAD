import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DNS } from '../models/DNS';

@Injectable()
export class DNSService {

  baseURL = 'https://localhost:7208/api/DNS';

  constructor(private http: HttpClient) { }


  getTodosDNSs(): Observable<DNS[]>{
    return this.http.get<DNS[]>(this.baseURL);
  }

  getDNSsByCliente(clienteId: number): Observable<DNS[]>{
    return this.http.get<DNS[]>(`${this.baseURL}/${clienteId}`)
  }

  public post(dns: DNS): Observable<DNS>{
    return this.http.post<DNS>(this.baseURL, dns);
  }

  public put(id: number, dns: DNS): Observable<DNS>{
    return this.http.post<DNS>(`${this.baseURL}/${id}`, dns);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`);
  }


}
