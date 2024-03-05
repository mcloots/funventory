import { ComponentFixture, TestBed } from '@angular/core/testing';
import { EduhubFrontendComponent } from './eduhub-frontend.component';

describe('EduhubFrontendComponent', () => {
  let component: EduhubFrontendComponent;
  let fixture: ComponentFixture<EduhubFrontendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EduhubFrontendComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(EduhubFrontendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
