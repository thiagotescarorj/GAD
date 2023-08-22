import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Chamado } from '../models/Chamado';
import { environment } from 'src/environments/environment';

@Injectable()
export class ChamadoService {

  baseURL = environment.apiURL  +  'api/Chamado';

  constructor(private http: HttpClient) { }

   public getTodosChamados(): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(this.baseURL);
  }

  public getChamadoById(id: number): Observable<Chamado>{
    return this.http.get<Chamado>(`${this.baseURL}/${id}`);
  }

  public getChamadosByNumero(numero: string): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${numero}`)
  }

  public getChamadosByCliente(clienteId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${clienteId}`)
  }

  public getChamadosByDNS(dnsId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${dnsId}`)
  }

  public getChamadosByBancoDados(bancoDadosId: number): Observable<Chamado[]>{
    return this.http.get<Chamado[]>(`${this.baseURL}/${bancoDadosId}`)
  }

  public post(chamado: Chamado): Observable<Chamado>{
    return this.http.post<Chamado>(this.baseURL, chamado);
  }

  public put(id: number, chamado: Chamado): Observable<Chamado>{
    return this.http.put<Chamado>(`${this.baseURL}/${id}`, chamado);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`);
  }



}
