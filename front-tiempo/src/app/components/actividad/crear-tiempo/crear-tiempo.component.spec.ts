import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearTiempoComponent } from './crear-tiempo.component';

describe('CrearTiempoComponent', () => {
  let component: CrearTiempoComponent;
  let fixture: ComponentFixture<CrearTiempoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CrearTiempoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrearTiempoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
