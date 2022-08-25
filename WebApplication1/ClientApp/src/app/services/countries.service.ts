import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CountryInfo } from '../Model/CountryInfo';
@Injectable({providedIn: 'root'})


export class ServiceNameService
{
  constructor(private httpClient: HttpClient) { }

}
@Injectable({ providedIn: 'root'})


export class CountriesService {
  // urls used for sending the Http request to API
  urlGetCountries:string='https://localhost:44380/api/Country/GetListofCountries';
  urlGetCountryById:string='https://localhost:44380/api/Country/GetCountryInfo';

  //Constructer
  constructor(private http:HttpClient ) { }


  //User Defined Functions

  // To get all the countries from the
  GetCountries():Observable<CountryInfo[]>
  {
   return this.http.get<CountryInfo[]>(this.urlGetCountries);

  }

  GetCountryById(countryId:number):Observable<CountryInfo>
  {
     // Initialize Params Object
     let params = new HttpParams();

     // Begin assigning parameters
     params = params.append('countryId', countryId.toString());

   return this.http.get<CountryInfo>(this.urlGetCountryById, {params: params});

  }

}
