import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveEmergenciesComponent } from './approve-emergencies.component';

describe('ApproveEmergenciesComponent', () => {
  let component: ApproveEmergenciesComponent;
  let fixture: ComponentFixture<ApproveEmergenciesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApproveEmergenciesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApproveEmergenciesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
