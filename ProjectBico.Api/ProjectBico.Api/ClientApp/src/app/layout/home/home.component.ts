import { Component } from '@angular/core';
import { User } from 'src/app/core/models/user';
import { AccountService } from 'src/app/core/services/account/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
    user: User;

    constructor(private accountService: AccountService) {
        this.user = this.accountService.userValue;
    }

    logout() {
      this.accountService.logout();
  }

  private editBody = false

  public aboutMeActive = false
  public particularsActive = false
  public extrasActive = false


  public doEditBody(){
    this.editBody = !this.editBody
  }
}
