import { ConditionalExpr } from '@angular/compiler';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CountryInfo } from '../Model/CountryInfo';
import { CountriesService } from '../services/countries.service';

@Component({
  selector: 'app-instructions-component',
  templateUrl: './instructions.component.html'
})
export class CounterComponent {

  // User Defined Properties

  listOfCountries:CountryInfo[]=[];
  countryDetails:CountryInfo = new CountryInfo();
  selectCountryForm !: FormGroup;
  showInstructions=false;

  //Constructor

  constructor
  (
     private Countryservice:CountriesService,
    private formBuilder: FormBuilder

   ) { }

   //NgoOnInit Hook

  ngOnInit(): void {
    this.selectCountryForm = this.formBuilder.group(
      {

          country: ['0', Validators.required],

      }
  );
    this.getCountries();

}

//This function is caleed when you select a country from the dropdown

SelectedCountry()
{
  this.showInstructions=true;
  let countryId = this.selectCountryForm.controls["country"].value as number;
  console.log(countryId);
  this.getCountryById(countryId);
}

// This function gets the list of country to populate then in the dropdown of this page
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

  // This function is to find the different parameters of selected country to show in the details page
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
