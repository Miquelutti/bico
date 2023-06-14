import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class SampleService {
    constructor(private http: HttpClient) { }

    getAppSettings(): Observable<string|any> {
        return this.http.get('/api/values/getAppSettings', { responseType: 'text' as 'json' });
    }
}