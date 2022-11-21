import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/core/models/login.model';
import { LoginService } from 'src/app/core/services/login/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  error =  false;
  novoLogin: LoginModel;

  constructor(
    private fb: FormBuilder,
    private loginService: LoginService,
    private router: Router
  ) {
    this.initializeForm();
  }

  ngOnInit() {
  }

  initializeForm() {
    this.loginForm = this.fb.group({
      'usuario': ['', Validators.required],
      'senha': ['', Validators.required]
    });
  }

  enviar() {
    if (this.loginForm.valid) {
      this.error = false;

      this.novoLogin = new LoginModel();

      this.novoLogin.email = this.loginForm.value.usuario;
      this.novoLogin.senha = this.loginForm.value.senha;

      this.loginService.fazerLogin(this.novoLogin).subscribe((resp: any) => {
        if (resp != null) {

          sessionStorage.setItem('tipoUsuario', resp.papel);

          if (resp.papel == 0) {
            this.router.navigateByUrl('/cliente');
          } else if (resp.papel == 2) {
            this.router.navigateByUrl('/venda');
          } else if (resp.papel == 3) {
            this.router.navigateByUrl('/produto');
          } 

        } else {
          this.error = true;
        }
      });
    }
  }

  fechar() {
    this.error = false;
  }

}
