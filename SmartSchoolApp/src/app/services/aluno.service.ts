import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, Observable } from 'rxjs';

import { Aluno } from '../models/Aluno';
import { environment } from '../../environments/environment.development';
import { PaginatedResult } from '../models/Pagination';


@Injectable({
  providedIn: 'root'
})
export class AlunoService {

  baseURL = `${environment.mainUrlAPI}aluno`;


  constructor(private http: HttpClient) { }

  getAll(page?: number, itemsPerPage?: number): Observable<PaginatedResult<Aluno[]>> {
    const paginatedResult: PaginatedResult<Aluno[]> = new PaginatedResult<Aluno[]>();

    let params = new HttpParams();

    if (page !== undefined && itemsPerPage !== undefined) {
      params = params.append('pageNumber', page.toString());
      params = params.append('pageSize', itemsPerPage.toString());
    }


    return this.http.get<Aluno[]>(this.baseURL, {observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body ?? [];  // Verifica se o corpo da resposta não é nulo

        const paginationHeader = response.headers.get('Pagination');
        if (paginationHeader !== null) {
          paginatedResult.pagination = JSON.parse(paginationHeader);
        }
        return paginatedResult;
     }));
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
