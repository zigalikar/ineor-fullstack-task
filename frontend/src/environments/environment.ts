import { Environment } from '../app/model/environment.model';

export const environment: Environment = {
  production: false,
  name: 'development',
  sentryDsn:
    'https://a06697763e69480fa61804c7fc8e7347@o1356861.ingest.sentry.io/6642709', // we don't usually log in a development environment as we want errors in the console for debugging
  apiUrl: 'http://localhost:5001/api',
};
