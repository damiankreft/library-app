import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, fakeAsync, TestBed } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService } from '@auth0/angular-jwt';

import { AccountSignInComponent } from '../../../components/accountComponents/sign-in/sign-in.component';

function createNewEvent(eventName: string, bubbles = false, cancelable = false) {
  let evt = document.createEvent('CustomEvent');
  evt.initCustomEvent(eventName, bubbles, cancelable, null);
  return evt;
}

describe('AccountSignInComponent', () => {
  let component: AccountSignInComponent;
  let fixture: ComponentFixture<AccountSignInComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      providers: [ FormBuilder, { provide: JwtHelperService, useFactory: () => new JwtHelperService() } ],
      declarations: [ AccountSignInComponent ],
      imports: [ HttpClientTestingModule, RouterTestingModule ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountSignInComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should update the login in the component', fakeAsync(() => {
    const loginFormGroup = fixture.componentInstance.formBuilder.group({key: 'email'});
    const loginInput = fixture.nativeElement.querySelector('input');
    const event = createNewEvent('input');
    loginInput.value = 'admin1@example.com';
    loginInput.dispatchEvent(event);
    fixture.detectChanges();
    
    expect(loginFormGroup.value).toBe(loginInput.value);
  }))
});
