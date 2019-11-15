import { InjectionToken, FactoryProvider } from '@angular/core';

export const WINDOW = new InjectionToken<Window>('window');

const windowFactoryProvider: FactoryProvider = {
    provide: WINDOW,
    useFactory: () => window
};

export const windowProviders = [windowFactoryProvider];
