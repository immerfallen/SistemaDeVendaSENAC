import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../../models/login.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private httpClient: HttpClient
  ) { }

  fazerLogin(body: LoginModel) {
    return this.httpClient.post(environment.serverUrl + '/api/login/verificalogin', body);
  }
}
