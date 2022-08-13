import * as Sentry from '@sentry/browser';
import { ErrorHandler, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable()
export class SentryErrorHandler implements ErrorHandler {
  constructor() {
    Sentry.init({
      dsn: environment.sentryDsn,
      environment: environment.name,
      tracesSampleRate: 1.0,
    });
  }

  handleError(error: any) {
    Sentry.captureException(error.originalError || error);
  }
}

export function getErrorHandler(): ErrorHandler {
  if (environment.production) return new SentryErrorHandler();
  return new ErrorHandler();
}
