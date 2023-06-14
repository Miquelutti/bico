import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "../../base.services";

@Injectable({
  providedIn: 'root'
})
export class RegistrationFormService extends BaseService {
  constructor(http: HttpClient) {
    super(http);
  }

}
