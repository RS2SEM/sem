import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KorisnikUrediComponent } from './korisnik-uredi.component';

describe('KorisnikUrediComponent', () => {
  let component: KorisnikUrediComponent;
  let fixture: ComponentFixture<KorisnikUrediComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KorisnikUrediComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KorisnikUrediComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
