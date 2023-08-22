import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BancoDados } from '../models/BancoDados';

@Injectable()
export class BancoDadosService {

  baseURL = 'https://localhost:7208/api/BancoDados';

  constructor(private http: HttpClient) { }

  getTodosBancosDados(): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(this.baseURL);
  }

  getBancoDadosById(id: number): Observable<BancoDados>{
    return this.http.get<BancoDados>(`${this.baseURL}/GetById?id=${id}`);
  }

  getBancoDadossByNumero(nome: string): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(`${this.baseURL}/GetByNome?nome=${nome}`)
  }


  getBancoDadossByCliente(clienteId: number): Observable<BancoDados[]>{
    return this.http.get<BancoDados[]>(`${this.baseURL}/GetByClienteId?clienteId=${clienteId}`)
  }

  public post(bancoDados: BancoDados): Observable<BancoDados>{
    return this.http.post<BancoDados>(this.baseURL, bancoDados);
  }

  public put(id: number, bancoDados: BancoDados): Observable<BancoDados>{
    return this.http.put<BancoDados>(`${this.baseURL}/${id}`, bancoDados);
  }

  public delete(id: number): Observable<any>{
    return this.http.delete(`${this.baseURL}/${id}`);
  }


}
