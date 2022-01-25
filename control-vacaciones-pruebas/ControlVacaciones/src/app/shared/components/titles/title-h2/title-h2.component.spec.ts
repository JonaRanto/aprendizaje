import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleH2Component } from './title-h2.component';

describe('TitleH2Component', () => {
  let component: TitleH2Component;
  let fixture: ComponentFixture<TitleH2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TitleH2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleH2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
