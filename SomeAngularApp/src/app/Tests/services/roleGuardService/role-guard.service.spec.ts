import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { JwtHelperService } from '@auth0/angular-jwt';

import { RoleGuardService } from '../../../services/roleGuardService/role-guard.service';

describe('RoleGuardService', () => {
  let service: RoleGuardService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        {
          provide: JwtHelperService,
          useFactory: () => new JwtHelperService()
        }
      ],
      imports: [ HttpClientTestingModule, RouterTestingModule ]
    });
    service = TestBed.inject(RoleGuardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
