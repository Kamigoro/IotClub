import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { SensorConfig } from '../sensor-config/models/sensor-config';

@Component({
  selector: 'app-sensor-configurator',
  templateUrl: './sensor-configurator.component.html',
  styleUrls: ['./sensor-configurator.component.scss']
})
export class SensorConfiguratorComponent implements OnInit {

  sensorsConfig$: Observable<SensorConfig[]> = new Observable;

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
    {
      this.sensorsConfig$ = this.httpClient.get<SensorConfig[]>("../../assets/sensors-config.json");
    }
  }

}
