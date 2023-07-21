
// import { Component, TemplateRef } from '@angular/core';
// import { ChamadoService } from '../../../services/chamado.service';
// import { Chamado } from '../../../models/Chamado';
// import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
// import { ToastrService } from 'ngx-toastr';
// import { NgxSpinnerService } from 'ngx-spinner';

import { Component, TemplateRef } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { Chamado } from "src/app/models/Chamado";
import { ChamadoService } from "src/app/services/chamado.service";



@Component({
  selector: 'app-chamados',
  templateUrl: './chamado-lista.component.html',
  styleUrls: ['./chamado-lista.component.scss'],


})
export class ChamadoListaComponent {
  modalRef?: BsModalRef;
  public chamadoNumero = '';
  public chamadoId = '';

  public Chamados: any = [{
    id: '',
    numero: '',
    isAtivo: '',
    dataHoraCadastro: '',
    dataRecebimento: '',
    dataEnvioHomologacao: '',
    dataPublicacao: '',
  }];
  public ChamadosFiltrados: any = [{
    id: '',
    numero: '',
    isAtivo: '',
    dataHoraCadastro: '',
    dataRecebimento: '',
    dataEnvioHomologacao: '',
    dataPublicacao: '',
  }];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.ChamadosFiltrados = this.filtroLista ? this.filtrarChamados(this.filtroLista) : this.Chamados;
  }

  public contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  public filtrarChamados(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.Chamados.filter(
      (chamado: {
        numero: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
        dataRecebimento: string,
        dataEnvioHomologacao: string,
        dataPublicacao: string
      }) => {
        const isAtivoStr = chamado.isAtivo ? "Ativo" : "Inativo";
        const dataHoraCadastroStr = chamado.dataHoraCadastro == null ? "" : chamado.dataHoraCadastro;
        const dataRecebimentoStr = chamado.dataRecebimento == null ? "" : chamado.dataRecebimento;
        const dataEnvioHomologacaoStr = chamado.dataEnvioHomologacao == null ? "" : chamado.dataEnvioHomologacao;
        const dataPublicacaoStr = chamado.dataPublicacao == null ? "" : chamado.dataPublicacao;
        return chamado.numero.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        || dataHoraCadastroStr.indexOf(filtrarPor) !== -1
        || dataRecebimentoStr.indexOf(filtrarPor) !== -1
        || dataEnvioHomologacaoStr.indexOf(filtrarPor) !== -1
        || dataPublicacaoStr.indexOf(filtrarPor) !== -1;
      }
      );
    }

    constructor(
      private chamadoService: ChamadoService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router
      ){}

      public ngOnInit(): void{
        this.spinner.show();
        this.getChamados();
      }



      public getChamados(): void{
        const Observer = {
          next:(_chamado: Chamado[]) => {
            this.Chamados = _chamado;
            this.ChamadosFiltrados = this.Chamados;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar os Chamados', 'Erro!')
          },
          complete: () => this.spinner.hide()

        }

        this.chamadoService.getTodosChamados().subscribe(Observer);



      }


      // Modal

      message?: string;

      openModal(event: any, template: TemplateRef<any>, chamadoNumero: string, chamadoId: string) {
        event.stopPropagation();
        this.chamadoNumero = chamadoNumero;
        this.chamadoId = chamadoId;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();

        this.chamadoService.delete(parseFloat(this.chamadoId)).subscribe(
          (result: any) => {
            console.log(result);
            this.toastr.success(`O Chamado ${this.chamadoNumero} foi deletado com sucesso.`, "Deletado!");
            this.spinner.hide();
            this.getChamados();

          },
          (error: any) => {
            console.error(error);
            this.toastr.error(`Erro ao tentar deletar o chamado de ID ${this.chamadoId}`, `Erro!`)
          },
          () => this.spinner.hide()
          );

        }

        decline(): void {
          this.modalRef?.hide();
        }

        editarChamado(id: number): void{
          this.router.navigate([`chamados/editar/${id}`]);  
        }

        detalheChamado(id: number): void{
          this.router.navigate([`chamados/detalhe/${id}`]);  
        }

        }

