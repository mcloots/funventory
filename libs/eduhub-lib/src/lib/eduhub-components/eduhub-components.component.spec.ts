import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EduhubComponentsComponent } from './eduhub-lib.component';

describe('EduhubComponentsComponent', () => {
  let component: EduhubComponentsComponent;
  let fixture: ComponentFixture<EduhubComponentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EduhubComponentsComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(EduhubComponentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
