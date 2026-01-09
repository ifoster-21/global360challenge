import { ApplicationConfig, provideBrowserGlobalErrorListeners } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';

import { routes } from './app.routes';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { provideDefaultClient } from '../api/providers';

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideDefaultClient({
      basePath: 'http://localhost:5124'
    }),
    provideBrowserGlobalErrorListeners(),
    provideRouter(routes), provideClientHydration(withEventReplay())
  ]
};
