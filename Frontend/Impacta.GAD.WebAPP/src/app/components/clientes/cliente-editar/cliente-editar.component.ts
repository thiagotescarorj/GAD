import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/Cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-editar',
  templateUrl: './cliente-editar.component.html',
  styleUrls: ['./cliente-editar.component.scss']
})
export class ClienteEditarComponent {
  cliente = {} as Cliente;
  clienteEditarForm!: FormGroup;
  router2: Router;
  
  
  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private clienteService: ClienteService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router2: Router)
    {
      this.localeService.use('pt-br');
      this.router2 = router2;
      
    }
    
    public salvar(): void{
      this.spinner.show();
      
      
      this.cliente = {... this.clienteEditarForm.value};
      
      
      this.clienteService.put(this.cliente.id, this.cliente).subscribe(
        () => this.toastr.success("Banco de Dados salvo com sucesso!", "Sucesso")
                         .onHidden.subscribe(() => {setTimeout(window.location.href ='/cliente/lista', 2000)}),
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error("Erro ao salvar Cliente", "Erro");
        },
        () => this.spinner.hide()
        );
        
      }
      
      
      public carregamentoCliente(): void{
        const clienteIdParam = this.router.snapshot.paramMap.get('id');
        
        if(clienteIdParam != null){
          this.spinner.show();
          this.clienteService.getClienteById(+clienteIdParam).subscribe(
            {
              next: (cliente: Cliente) => {
                this.cliente = {...cliente};
                this.clienteEditarForm.patchValue(this.cliente);
              },
              error: () => {
                this.spinner.hide();
                this.toastr.error("Erro ao carregar o Banco de Dados.", "Erro!")
              },
              complete:  () => {
                this.spinner.hide();
              }
            });
          }
          
        }
        
        ngOnInit(): void {
          this.carregamentoCliente();
          this.clienteEditarForm = new FormGroup({
            id: new FormControl(''),
            nome: new FormControl('',[Validators.required]),
            isAtivo: new FormControl('',[Validators.required]),                        
          });
        }
        
        get nome(){
          return this.clienteEditarForm.get('nome')!;
        }
        
        get clienteId(){
          return this.clienteEditarForm.get('clienteId')!;
        }
        
        get isAtivo(){
          return this.clienteEditarForm.get('isAtivo')!;
        }
        
        
        submit(){
          if(this.clienteEditarForm.invalid){
            return;
          }
          console.log('Atualizado Formulário')
        }
        
        resetForm(event: any): void{
          event.preventDefault();
          this.clienteEditarForm.reset();
        }
        
        get bsConfig(): any{
          return {
            adaptivePosition: true,
            dateInputFormat: 'DD/MM/YYYY',
            containerClass: 'theme-orange',
            showWeekNumbers: false,
          }
        }
        
      

}
