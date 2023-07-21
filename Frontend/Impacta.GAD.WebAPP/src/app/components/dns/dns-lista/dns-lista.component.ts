import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { DNS } from 'src/app/models/DNS';
import { DNSService } from 'src/app/services/dns.service';

@Component({
  selector: 'app-dns-lista',
  templateUrl: './dns-lista.component.html',
  styleUrls: ['./dns-lista.component.scss']
})
export class DnsListaComponent {

  modalRef?: BsModalRef;
  dnsId = '';
  dnsName = '';

  public DNSList: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    cliete: '',
    dataHoraCadastro: '',
  }];
  public DNSListFiltrados: any = [{
    id: '',
    nome: '',
    isAtivo: '',
    cliente: '',
    dataHoraCadastro: '',
  }];

  private _filtroLista: string = '';

  public get filtroLista(): string{
    return this._filtroLista;
  }

  public set filtroLista(value: string){
    this._filtroLista = value;
    this.DNSListFiltrados = this.filtroLista ? this.filtrarDNSList(this.filtroLista) : this.DNSList;
  }

  public contemLetra(string: string, letra: string): boolean {
    let valor  =  string.toLowerCase().includes(letra.toLowerCase());
    return valor;
  }

  public filtrarDNSList(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.DNSList.filter(
      (dns: {
        nome: string,
        isAtivo: boolean,
        dataHoraCadastro: string,
      }) => {
        const isAtivoStr = dns.isAtivo ? "Ativo" : "Inativo";
        const dataHoraCadastroStr = dns.dataHoraCadastro == null ? "" : dns.dataHoraCadastro;
        return dns.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || isAtivoStr.toLocaleLowerCase().indexOf(filtrarPor) !== -1
          || dataHoraCadastroStr.indexOf(filtrarPor) !== -1;
      }
    );
  }

  constructor(
    private dnsService: DNSService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ){}

  public ngOnInit(): void{
    this.spinner.show();
    this.getDNSList();
  }



  public getDNSList(): void{
    const Observer = {
      next:(_dns: DNS[]) => {
        this.DNSList = _dns;
        this.DNSListFiltrados = this.DNSList;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os DNSList', 'Erro!')
      },
      complete: () => this.spinner.hide()

    }

    this.dnsService.getTodosDNSs().subscribe(Observer);



  }


  // Modal

  message?: string;

  openModal(evet: any, template: TemplateRef<any>, dnsnName: string, dnsId: string) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();

    this.spinner.show();

        this.dnsService.delete(parseFloat(this.dnsId)).subscribe(
          (result: any) => {
            console.log(result);
            this.toastr.success(`O DNS ${this.dnsName} foi deletado com sucesso.`, "Deletado!");
            this.spinner.hide();
            this.getDNSList();

          },
          (error: any) => {
            console.error(error);
            this.toastr.error(`Erro ao tentar deletar o dns de ID ${this.dnsId}`, `Erro!`)
          },
          () => this.spinner.hide()
          );
  }

  decline(): void {
    this.modalRef?.hide();
  }

  editarDNS(id: number): void{
    this.router.navigate([`dns/editar/${id}`]);
  }

  detalheDNS(id: number): void{
    this.router.navigate([`dns/detalhe/${id}`]);
  }


}
