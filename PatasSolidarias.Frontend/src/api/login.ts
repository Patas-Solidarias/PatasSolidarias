export class LoginRequest {
  email: string | undefined;
  senha: string | undefined;
}

export class LoginResponse {
  token: string | undefined;
}
