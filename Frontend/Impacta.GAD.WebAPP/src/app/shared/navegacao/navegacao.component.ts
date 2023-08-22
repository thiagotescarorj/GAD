import { AccountService } from 'src/app/services/account.service';
import { Component, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navegacao',
  templateUrl: './navegacao.component.html',
  styleUrls: ['./navegacao.component.css']
})
export class NavegacaoComponent implements OnInit {
  isCollapsed = true;
  corFundo: string = 'white';



  constructor(public accountService: AccountService,private router: Router,
              private renderer: Renderer2) { }

  ngOnInit() {
  }
  logout():void{
    this.accountService.logout();
    this.router.navigateByUrl("user/login");
  }
y
  changeColor() {
    if (this.corFundo === 'white') {
      this.corFundo = 'gray';
    } else {
      this.corFundo = 'white';
    }

    this.renderer.setStyle(document.body, 'background-color', this.corFundo);
  }

  showMenu(): boolean {
    const allowedUrls = ['/user/login', '/user/registration'];
    if (allowedUrls.includes(this.router.url)){
      return false;
    }
    return true;
  }

}
