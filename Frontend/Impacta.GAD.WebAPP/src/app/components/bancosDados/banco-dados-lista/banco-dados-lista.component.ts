import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BancoDados } from 'src/app/models/BancoDados';
import { BancoDadosService } from 'src/app/services/bancoDados.service';

@Component({
  selector: 'app-banco-dados-lista',
  templateUrl: './banco-dados-lista.component.html',
  styleUrls: ['./banco-dados-lista.component.scss']
})
export class BancoDadosListaComponent {

  modalRef?: BsModalRef;
  bancoDadosName ='';
  bancoDadosId ='';

  public BancoDadosList: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    cliete: '',
    dataHoraCadastro: '',
  }];

  public BancoDadosListFiltrados: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    cliete: '',
    dataHoraCadastro: '',
  }];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.BancoDadosListFiltrados = this.filtroLista ? this.filtrarBancoDadosList(this.filtroLista) : this.BancoDadosList;
  }

  public contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  public filtrarBancoDadosList(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.BancoDadosList.filter(
      (bancoDados: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = bancoDados.isAtivo ? "Ativo" : "Inativo";
        const dataHoraCadastroStr = bancoDados.dataHoraCadastro == null ? "" : bancoDados.dataHoraCadastro;
        return bancoDados.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        || dataHoraCadastroStr.indexOf(filtrarPor) !== -1;
      }
      );
    }

    constructor(
      private bancoDadosService: BancoDadosService,
      private modalService: BsModalService,
      private toastr: ToastrService,
      private spinner: NgxSpinnerService,
      private router: Router
      ){}

      public ngOnInit(): void{
        this.spinner.show();
        this.getBancoDadosList();
      }



      public getBancoDadosList(): void{
        const Observer = {
          next:(_bancoDados: BancoDados[]) => {
            this.BancoDadosList = _bancoDados;
            this.BancoDadosListFiltrados = this.BancoDadosList;
          },
          error: (error: any) => {
            this.spinner.hide();
            this.toastr.error('Erro ao carregar os BancoDadosList', 'Erro!')
          },
          complete: () => this.spinner.hide()

        }

        this.bancoDadosService.getTodosBancosDados().subscribe(Observer);



      }


      // Modal

      message?: string;

      openModal(event: any, template: TemplateRef<any>, bancoDadosName: string, bancoDadosId: string) {
        event.stopPropagation();
        this.bancoDadosName = bancoDadosName;
        this.bancoDadosId = bancoDadosId;
        this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
      }

      confirm(): void {
        this.modalRef?.hide();
        this.spinner.show();
        this.bancoDadosService.delete(parseFloat(this.bancoDadosId)).subscribe(
          (result: any) => {
            console.log(result);
            this.toastr.success(`O Banco de Dados ${this.bancoDadosName} foi deletado com sucesso.`);
            this.spinner.hide();
            this.getBancoDadosList();
          },
          (error: any) => {
            console.error(error);
            this.toastr.error(`Erro ao tentar deletar o Banco de Dados ${this.bancoDadosName}`);
          },
          () => this.spinner.hide()
          );
        }

        decline(): void {
          this.modalRef?.hide();
        }

        editarBancoDados(id: number): void{
          this.router.navigate([`bancoDados/editar/${id}`]);
        }

        detalheBancoDados(id: number): void{
          this.router.navigate([`bancoDados/detalhe/${id}`]);
        }


      }
