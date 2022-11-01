import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorConfiguratorComponent } from './sensor-configurator.component';

describe('SensorConfiguratorComponent', () => {
  let component: SensorConfiguratorComponent;
  let fixture: ComponentFixture<SensorConfiguratorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorConfiguratorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SensorConfiguratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
