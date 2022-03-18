import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AsdfComponent } from './asdf.component';

describe('AsdfComponent', () => {
  let component: AsdfComponent;
  let fixture: ComponentFixture<AsdfComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AsdfComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AsdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
