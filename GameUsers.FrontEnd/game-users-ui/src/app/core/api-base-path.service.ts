import { Injectable, Inject } from '@angular/core';
import { WINDOW } from './providers/window-provider';

@Injectable({
    providedIn: 'root'
})
export class ApiBasePathService {
    private readonly apiPort = '5555';

    constructor(@Inject(WINDOW) private window: Window) {}

    private getBasePath(): string {
        return `${this.window.location.protocol}//${this.window.location.hostname}`;
    }

    public getApiBasePath(): string {
        return `${this.getBasePath()}:${this.apiPort}`;
    }
}
