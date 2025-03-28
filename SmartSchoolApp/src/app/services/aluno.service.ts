import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Aluno } from '../models/Aluno';
import { environment } from '../../environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  baseURL = `${environment.mainUrlAPI}aluno`;


  constructor(private http: HttpClient) { }

  getAll(): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(this.baseURL);
  }

  getById(id: number): Observable<Aluno> {
    return this.http.get<Aluno>(`${this.baseURL}/${id}`);
  }

  getByDisciplinaId(id: number): Observable<Aluno[]> {
    return this.http.get<Aluno[]>(`${this.baseURL}/ByDisciplina/${id}`);
  }

  post(aluno: any): Observable<any> {
    return this.http.post(this.baseURL, aluno);
  }

  put(aluno: any): Observable<any> {
    return this.http.put(`${this.baseURL}/${aluno.id}`, aluno);
  }

  trocarEstado(alunoId: number, ativo: boolean): Observable<any> {
    return this.http.patch(`${this.baseURL}/${alunoId}/trocarEstado`, {estado: ativo });
  }

  patch(aluno: any): Observable<any> {
    return this.http.patch(`${this.baseURL}/${aluno.id}`, aluno);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

}
