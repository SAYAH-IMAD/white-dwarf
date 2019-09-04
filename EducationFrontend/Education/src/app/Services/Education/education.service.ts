import { Injectable } from '@angular/core';
import { Education } from 'src/app/Models/Education';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EducationService {

  constructor(private http: HttpClient) { }

  public getEducations(userId: number): Observable<Education[]> {
     return this.http.get<Education[]>('https://localhost:5001/api/v1/user/1/education/getEducations');
  }

  public getEducation(userId: number, educationId: number): Observable<Education> {
    return this.http.get<Education>('https://localhost:5001/api/v1/user/1/education/getEducation/' + educationId);
 }
  public addEducation(education: Education): void {

    let headers = new HttpHeaders();
    headers = headers
              .set('Content-Type', 'application/json');

    this.http.post<Education>('https://localhost:5001/api/v1/user/1/education/createEducation', education, {headers})
     .subscribe(Response => {
         console.log('success');
       },
       err => {
       console.log('error');
       });
  }
  public updateEducation(educationId: number, education: Education){

    let headers = new HttpHeaders();
    headers = headers
              .set('Content-Type', 'application/json');


    this.http.put('https://localhost:5001/api/v1/user/1/education/putEducation/' + educationId, education , {headers})
    .subscribe(Response => {
      console.log('success');
    },
    err => {
      console.log('error');
    });
  }
}
