import { Environment } from '../app/model/environment.model';

export const environment: Environment = {
  production: false,
  name: 'development',
  sentryDsn: 'https://b6aa48a48fb445fe9db4dc2993ef94e2@o1356861.ingest.sentry.io/6642696', // we don't usually log in a development environment as we want errors in the console for debugging
  apiUrl: 'http://localhost:5001/api',
};
