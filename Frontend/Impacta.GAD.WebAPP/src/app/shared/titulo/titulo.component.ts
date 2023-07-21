import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {
  @Input() titulo!: string;
  @Input() iconClass =  'fa-solid fa-mug-saucer';
  @Input() subtitulo = 'GAD - Gerenciador da Área de Desenvolvimento';
  @Input() botaoListar = false;

  constructor(private router: Router) { }

  ngOnInit() {
  }

  listar(): void{
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`])
  }

}
