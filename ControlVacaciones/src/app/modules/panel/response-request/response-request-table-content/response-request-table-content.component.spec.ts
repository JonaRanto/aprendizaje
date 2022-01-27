import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ResponseRequestTableContentComponent } from './response-request-table-content.component';

describe('ResponseRequestTableContentComponent', () => {
  let component: ResponseRequestTableContentComponent;
  let fixture: ComponentFixture<ResponseRequestTableContentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ResponseRequestTableContentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ResponseRequestTableContentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
