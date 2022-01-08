import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GenericResourceDto } from 'src/app/Dto/generic-resource-dto';

@Injectable({
  providedIn: 'root'
})
export class LibraryService {
  private libraryUri: string;
  private findPath = "/find?=";
      
  constructor(private http: HttpClient) {
    this.libraryUri = environment.libraryResourceService;
  }

  getGenericResourcesByTitle(title: string): Observable<GenericResourceDto[]> {
    return this.http.get<GenericResourceDto[]>(this.libraryUri + this.findPath + title);
  }

  getGenericResources(): Observable<GenericResourceDto[]> {
    return this.http.get<GenericResourceDto[]>(this.libraryUri);
  }

  lease(): void {
    alert("Wypożyczono. Książka czeka na Ciebie w bibliotece!");
  }
}
