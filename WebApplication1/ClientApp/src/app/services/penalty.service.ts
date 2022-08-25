import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PenaltyInfo } from '../Model/PenaltyInfo';

@Injectable({
  providedIn: 'root'
})
export class PenaltyService {
  urlGetPenaltyAmount:string='https://localhost:44380/api/Penalty/Calculate';

  constructor(private http:HttpClient) { }

  GetPenaltyAmount(startDate:Date, endDate:Date, countryId:number):Observable<PenaltyInfo>
  {
     // Initialize Params Object
     let params = new HttpParams();

     // Begin assigning parameters
     params = params.append('startDate', startDate.toISOString());
     params = params.append('endDate', endDate.toISOString());
     params = params.append('countryId', countryId.toString());

   return this.http.get<PenaltyInfo>(this.urlGetPenaltyAmount, {params: params});

  }
}
