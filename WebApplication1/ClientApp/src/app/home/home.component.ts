import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryInfo } from '../Model/CountryInfo';
import { PenaltyInfo } from '../Model/PenaltyInfo';
import { CountriesService } from '../services/countries.service';
import { PenaltyService } from '../services/penalty.service';

@Component({
    selector: 'app-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  //User Defined Properties

    showCalculation = false;
    listOfCountries:CountryInfo[]=[];
    countryDetails:CountryInfo = new CountryInfo();
    penaltyInfo:PenaltyInfo = new PenaltyInfo();
    BusinessDays = 15;
    penaulty = '300 PKR';
    inputDatesForm !: FormGroup;

    //Constructor

    constructor(private formBuilder: FormBuilder,
      private Countryservice:CountriesService,
      private Penaultyservice:PenaltyService) { }

      //The Method which is called after the constrctor

    ngOnInit(): void {

        //Making The Reactive Form

        this.inputDatesForm = this.formBuilder.group(
            {
                checkedOutDate: ['', Validators.required],
                returedDate: ['', Validators.required],
                country: ['0', Validators.required],
            }
        );
        this.getCountries();
    }

  // This function calculates the penaulty amount and business days by sending the checkedout date,
  // returned date and the the country selected to the api

    calculate() {
        this.showCalculation = true;
        let startDate = new Date(this.inputDatesForm.controls["checkedOutDate"].value);
        let endDate = new Date(this.inputDatesForm.controls["returedDate"].value);
        let countryId = this.inputDatesForm.controls["country"].value as number;
        this.getCountryById(countryId);
        this.getPenaltyInfo(startDate, endDate, countryId);

    }

    // This function is specifically used to calculate the penaulty amount

    getPenaltyInfo(startDate:Date, endDate:Date, countryId:number)
    {
      this.Penaultyservice.GetPenaltyAmount(startDate, endDate, countryId)
      .subscribe(
        data=>
        {
          this.penaltyInfo = data;
       },
       error=>{
        console.log(error);
      });
    }


    //This Function gets the list of all countries present in the database

    getCountries()
    {
      this.Countryservice.GetCountries()
      .subscribe(
        data=>
        {
          this.listOfCountries = data;
       },
       error=>{
        console.log(error);
      });
    }

    // This function is to calculate the specific country by using the country id

    getCountryById(countryId:number){
      this.Countryservice.GetCountryById(countryId)
      .subscribe(
        data=>
        {
          this.countryDetails = data;
       },
       error=>{
        console.log(error);
      });
    }
}
