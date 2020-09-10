import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weather-info',
  templateUrl: './weather-info.component.html',
  styleUrls: ['./weather-info.component.css']
})

export class WeatherInfoComponent {

  public forecasts: WeatherInfo;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<WeatherInfo>(baseUrl + 'weatherforecast').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Location {
  name: string;
}

interface Condition {
  text: string;
  icon: string;
}

interface Current {
  temp: number;
  condition: Condition;
  wind_kph: number;
  precipitation: number;
  humidity: number;
  uv: number;
}

interface WeatherInfo {
  location: Location;
  current: Current;
  date: string;
  risk: string;
}
