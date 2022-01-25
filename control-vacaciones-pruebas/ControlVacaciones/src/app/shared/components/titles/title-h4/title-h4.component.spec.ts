import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleH4Component } from './title-h4.component';

describe('TitleH4Component', () => {
  let component: TitleH4Component;
  let fixture: ComponentFixture<TitleH4Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TitleH4Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleH4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
