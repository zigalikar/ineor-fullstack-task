export interface JwtToken {
  aud: string;
  exp: number;
  given_name: string;
  iat: number;
  iss: string;
  nameid: string;
  nbf: number;
  role?: string;
}
