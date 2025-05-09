import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEmergencyComponent } from './create-emergency.component';

describe('CreateEmergencyComponent', () => {
  let component: CreateEmergencyComponent;
  let fixture: ComponentFixture<CreateEmergencyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateEmergencyComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateEmergencyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
