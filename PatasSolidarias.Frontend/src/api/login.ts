export class LoginRequest {
  email: string | undefined;
  password: string | undefined;
}

export class LoginResponse {
  token: string | undefined;
}
