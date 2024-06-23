import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminApiAuthApiClient, AuthenticatedResult, LoginRequest } from 'src/app/api/admin-api.service.generated';
import {AlertService} from 'src/app/shared/services/alert.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  constructor(
    private fb: FormBuilder, 
    private authApiClient: AdminApiAuthApiClient,
    private alertService: AlertService,
    private router: Router) { 
    this.loginForm = fb.group({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }
  loginForm: FormGroup;

  login() {
    var request: LoginRequest = new LoginRequest({
      userName: this.loginForm.controls['userName'].value,
      password: this.loginForm.controls['password'].value 
    });

    this.authApiClient.login(request).subscribe({
      next: (res: AuthenticatedResult) => {
        this.router.navigate(['/dashboard']);
      },
      error: (err: any) => {
        this.alertService.showError("Login Invalid")
      }
    });
  }
}

