import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorConfigComponent } from './sensor-config.component';

describe('SensorConfigComponent', () => {
  let component: SensorConfigComponent;
  let fixture: ComponentFixture<SensorConfigComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorConfigComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SensorConfigComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
