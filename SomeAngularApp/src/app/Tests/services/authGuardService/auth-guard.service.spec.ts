import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService } from '@auth0/angular-jwt';

import { AuthGuardService } from '../../../services/authGuardService/auth-guard.service';

describe('AuthGuardService', () => {
  let service: AuthGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ 
        {
           provide: JwtHelperService,
           useFactory: () => new JwtHelperService()
        }
      ],
      imports: [ HttpClientTestingModule, RouterTestingModule ]
    })
    .compileComponents();
    service = TestBed.inject(AuthGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
