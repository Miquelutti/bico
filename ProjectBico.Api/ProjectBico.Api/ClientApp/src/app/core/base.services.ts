import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";

export abstract class BaseService {
    constructor(public http: HttpClient) { }

    doGet<T>(method: string): Observable<T> {
      return this.http.get<T>(this.BasePath() + method);
    }

    doPost<T>(method: string, body: any): Observable<T> {
      return this.http.post<T>(this.BasePath() + method, body);
    }

    doPut<T>(method: string, body: any): Observable<T> {
      return this.http.put<T>(this.BasePath() + method, body);
    }

    doDelete<T>(method: string): Observable<T> {
      return this.http.delete<T>(this.BasePath() + method);
    }

    protected BasePath(): string {
      return environment.bicoapi + '/api/';
    }
}
