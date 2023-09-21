// import { Component, TemplateRef } from '@angular/core';
// import { Router } from '@angular/router';
// import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
// import { NgxSpinnerService } from 'ngx-spinner';
// import { ToastrService } from 'ngx-toastr';
// import { Cliente } from 'src/app/models/Cliente';
// import { Pagination } from 'src/app/models/Pagination';
// import { ClienteService } from 'src/app/services/cliente.service';

// @Component({
//   selector: 'app-cliente-lista',
//   templateUrl: './cliente-lista.component.html',
//   styleUrls: ['./cliente-lista.component.scss']
// })
// export class ClienteListaComponent {

//   modalRef?: BsModalRef;
//   clienteId = '';
//   clienteName = '';
//   public pagination = {} as Pagination;

//   public Clientes: any = [{
//     id: '',
//     nome: '',
//     isAtivo: '',
//     dataHoraCadastro: '',
//   }];
//   public ClientesFiltrados: any = [{
//     id: '',
//     nome: '',
//     isAtivo: '',
//     dataHoraCadastro: '',
//   }];

//   private _filtroLista: string = '';

//   public get filtroLista(): string{
//     return this._filtroLista;
//   }

//   public set filtroLista(value: string){
//     this._filtroLista = value;
//     this.ClientesFiltrados = this.filtroLista ? this.filtrarClientes(this.filtroLista) : this.Clientes;
//   }

//   public contemLetra(string: string, letra: string): boolean {
//     let valor  =  string.toLowerCase().includes(letra.toLowerCase());
//     return valor;
//   }

//   public filtrarClientes(filtrarPor: string): any {
//     filtrarPor = filtrarPor.toLocaleLowerCase();
//     return this.Clientes.filter(
//       (cliente: {
//         nome: string,
//         isAtivo: boolean,
//         dataHoraCadastro: string,
//       }) => {
//         const isAtivoStr = cliente.isAtivo ? "Ativo" : "Inativo";
//         const dataHoraCadastroStr = cliente.dataHoraCadastro == null ? "" : cliente.dataHoraCadastro;
//         return cliente.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
//           || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
//           || dataHoraCadastroStr.indexOf(filtrarPor) !== -1;
//       }
//     );
//   }

//   constructor(
//     private clienteService: ClienteService,
//     private modalService: BsModalService,
//     private toastr: ToastrService,
//     private spinner: NgxSpinnerService,
//     private router: Router
//   ){}

//   public ngOnInit(): void{

//     this.pagination = {
//       currentPage: 1,
//       itemsPerPage: 3,
//       totalItems: 1,
//     } as Pagination;

//     this.getClientes();
//   }



//   public getClientes(): void{
//     const Observer = {
//       next:(_cliente: Cliente[]) => {
//         this.Clientes = _cliente;
//         this.ClientesFiltrados = this.Clientes;
//       },
//       error: (error: any) => {
//         this.spinner.hide();
//         this.toastr.error('Erro ao carregar os Clientes', 'Erro!')
//       },
//       complete: () => this.spinner.hide()

//     }

//     this.spinner.show();


//     this.clienteService.getTodosClientes().subscribe(Observer);



//   }


//   // Modal

//   message?: string;

//   openModal(event: any, template: TemplateRef<any>, clienteName: string, clienteId: string ) {
//     event.stopPropagation();
//     this.clienteName = clienteName;
//     this.clienteId = clienteId;
//     this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
//   }

//   confirm(): void {
//     this.modalRef?.hide();
//     this.spinner.show();

//         this.clienteService.delete(parseFloat(this.clienteId)).subscribe(
//           (result: any) => {
//             console.log(result);
//             this.toastr.success(`O Cliente ${this.clienteName} foi deletado com sucesso.`, "Deletado!");
//             this.spinner.hide();
//             this.getClientes();
//           },
//           (error: any) => {
//             console.error(error);
//             this.toastr.error(`Erro ao tentar deletar o cliente de ID ${this.clienteId}`, `Erro!`)
//           },
//           () => this.spinner.hide()
//           );

//   }

//   decline(): void {
//     this.modalRef?.hide();
//   }

//   editarCliente(id: number): void{
//     this.router.navigate([`clientes/editar/${id}`]);
//   }

//   detalheCliente(id: number): void{
//     this.router.navigate([`clientes/detalhe/${id}`]);
//   }

//   public pageChanged(event): void {
//     this.pagination.currentPage = event.page;
//     this.getClientes();
//   }


// }

import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
//import { Cliente } from '@app/models/Cliente';
//import { ClienteService } from '@app/services/cliente.service';
//import { environment } from '@environments/environment';
//import { PaginatedResult, Pagination } from '@app/models/Pagination';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { Cliente } from 'src/app/models/Cliente';
import { PaginatedResult, Pagination } from 'src/app/models/Pagination';
import { ClienteService } from 'src/app/services/cliente.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cliente-lista',
  templateUrl: './cliente-lista.component.html',
  styleUrls: ['./cliente-lista.component.scss'],
})
export class ClienteListaComponent implements OnInit {
  modalRef: BsModalRef;
  public clientes: Cliente[] = [];
  public clienteId = 0;
  public pagination = {} as Pagination;

  public larguraImagem = 150;
  public margemImagem = 2;
  public exibirImagem = true;

  termoBuscaChanged: Subject<string> = new Subject<string>();

  public filtrarClientes(evt: any): void {
    if (this.termoBuscaChanged.observers.length === 0) {
      this.termoBuscaChanged
      .pipe(debounceTime(1000))
      .subscribe((filtrarPor) => {
        this.spinner.show();
        this.clienteService
        .getClientes(
          this.pagination.currentPage,
          this.pagination.itemsPerPage,
          filtrarPor
          )
          .subscribe(
            (paginatedResult: PaginatedResult<Cliente[]>) => {
              this.clientes = paginatedResult.result;
              this.pagination = paginatedResult.pagination;
            },
            (error: any) => {
              this.spinner.hide();
              this.toastr.error('Erro ao Carregar os Clientes', 'Erro!');
            }
            )
            .add(() => this.spinner.hide());
          });
        }
        this.termoBuscaChanged.next(evt.value);
      }

      constructor(
        private clienteService: ClienteService,
        private modalService: BsModalService,
        private toastr: ToastrService,
        private spinner: NgxSpinnerService,
        private router: Router
        ) {}

        public ngOnInit(): void {
          this.pagination = {
            currentPage: 1,
            itemsPerPage: 10,
            totalItems: 1,
          } as Pagination;

          this.carregarClientes();
        }

        public alterarImagem(): void {
          this.exibirImagem = !this.exibirImagem;
        }

        public mostraImagem(imagemURL: string): string {
          return imagemURL !== ''
          ? `${environment.apiURL}resources/images/${imagemURL}`
          : 'assets/img/semImagem.jpeg';
        }

        public carregarClientes(): void {
          this.spinner.show();

          this.clienteService
          .getClientes(this.pagination.currentPage, this.pagination.itemsPerPage)
          .subscribe(
            (paginatedResult: PaginatedResult<Cliente[]>) => {
              this.clientes = paginatedResult.result;
              this.pagination = paginatedResult.pagination;
            },
            (error: any) => {
              this.spinner.hide();
              this.toastr.error('Erro ao Carregar os Clientes', 'Erro!');
            }
            )
            .add(() => this.spinner.hide());
          }

          openModal(event: any, template: TemplateRef<any>, clienteId: number): void {
            event.stopPropagation();
            this.clienteId = clienteId;
            this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
          }

          public pageChanged(event): void {
            this.pagination.currentPage = event.page;
            this.carregarClientes();
          }

          confirm(): void {
            this.modalRef.hide();
            this.spinner.show();

            this.clienteService
            .deleteCliente(this.clienteId)
            .subscribe(
              (result: any) => {
                if (result.message === 'Deletado') {
                  this.toastr.success(
                    'O Cliente foi deletado com Sucesso.',
                    'Deletado!'
                    );
                    this.carregarClientes();
                  }
                },
                (error: any) => {
                  console.error(error);
                  this.toastr.error(
                    `Erro ao tentar deletar o cliente ${this.clienteId}`,
                    'Erro'
                    );
                  }
                  )
                  .add(() => this.spinner.hide());
                }

                decline(): void {
                  this.modalRef.hide();
                }

                detalheCliente(id: number): void {
                  this.router.navigate([`clientes/detalhe/${id}`]);
                }

                editarCliente(id: number): void{
                  this.router.navigate([`clientes/editar/${id}`]);
                }
              }

