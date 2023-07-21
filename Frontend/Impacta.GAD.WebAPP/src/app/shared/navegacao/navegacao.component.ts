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


  constructor(private router: Router,
              private renderer: Renderer2) { }

  ngOnInit() {
  }

  changeColor() {
    if (this.corFundo === 'white') {
      this.corFundo = 'gray';
    } else {
      this.corFundo = 'white';
    }

    this.renderer.setStyle(document.body, 'background-color', this.corFundo);
  }

  showMenu(): boolean{
    return this.router.url != '/user/login';
  }

}
