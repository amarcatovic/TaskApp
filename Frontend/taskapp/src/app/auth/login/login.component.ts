import { Router } from '@angular/router';
import { AuthService } from '../../core/services/auth.service';
import { UsersService } from '../../core/services/users.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  isLoading: boolean = false;

  constructor(private userService: UsersService,
    private authService: AuthService,
    private router: Router,
    private fb: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  logUserIn() {
    this.isLoading = true;
    this.authService.logUserIn(this.loginForm.value)
      .subscribe(response => {
        this.getUserById(response.user.id, response.token);
      });
  }

  private getUserById(id: number, token: string) {
    this.userService.getUserById(id)
      .subscribe(user => {
        localStorage.setItem('user', JSON.stringify(user));
        localStorage.setItem('token', token);
        this.isLoading = false;
        this.authService.userHasLoggedIn();
        this.router.navigate(['/']);
      });
  }
}
