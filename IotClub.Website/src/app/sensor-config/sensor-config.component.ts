import { Component, Input, OnInit } from '@angular/core';
import { SensorConfig } from './models/sensor-config';

@Component({
  selector: 'app-sensor-config',
  templateUrl: './sensor-config.component.html',
  styleUrls: ['./sensor-config.component.scss']
})
export class SensorConfigComponent implements OnInit {

  @Input() sensorConfig?: SensorConfig;

  constructor() {
  }

  ngOnInit(): void {
  }

  calibrate(){

  }
  
  save(){

  }
}
