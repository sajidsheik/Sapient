import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Medicine[];
   public forecast:Medicine;
   public  medicineName:string;
   private http: HttpClient;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http=http;
    http.get<Medicine[]>(baseUrl + 'api/SampleData/Get').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }

  handleSearch(){
    let baseUrl = "https://localhost:44358/";
    this.http.get<Medicine>(baseUrl + 'api/SampleData/GetSelected?medicineName='+"Paracetomal").subscribe(result => {
      this.forecast = result;
    }, error => console.error(error));

  }
}

interface Medicine {
 
   medicineName :string;

         brand : string;

       price :number 

          quantity :number;

        expirayDate : Date;

         notes :string;
}
