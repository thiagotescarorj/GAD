import { User } from './models/identity/User';
import { AccountService } from 'src/app/services/account.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'GDA';

  constructor(public accountService: AccountService){}

  ngOnInit(): void{
    this.setCurrentUser();
  }

  setCurrentUser(): void {
    let user: User;

    if(localStorage.getItem('user')){
      user = JSON.parse(localStorage.getItem('user') ?? '{}')
    }else{
      user = null
    }

    if(user){
      this.accountService.setCurrentUser(user);
    }

  }

}
