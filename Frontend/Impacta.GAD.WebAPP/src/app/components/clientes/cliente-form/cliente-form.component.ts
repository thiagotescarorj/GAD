import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Cliente } from 'src/app/models/Cliente';
import { ClienteService } from 'src/app/services/cliente.service';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.scss']
})
export class ClienteFormComponent implements OnInit {

  cliente = {} as Cliente;
  clienteForm!: FormGroup;
  router: Router;

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private clienteService: ClienteService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router: Router){
      this.localeService.use('pt-br');
      this.router = router;
    }

    public salvar(): void{
      this.spinner.show();


      this.cliente = {... this.clienteForm.value};

      this.cliente.id = 0;

      this.clienteService.post(this.cliente).subscribe(
        () => {
          this.toastr.success("Cliente salvo com sucesso!", "Sucesso")
                     .onHidden.subscribe(() => {setTimeout(window.location.href ='/cliente/lista', 2000);})

        },
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error("Erro ao salvar Cliente", "Erro");
        },
        () => this.spinner.hide()
        );


      }

      ngOnInit(): void {
        this.clienteForm = new FormGroup({
          id: new FormControl(''),
          nome: new FormControl('', Validators.required),
          clienteId: new FormControl('', Validators.required),

        });
      }

      get nome(){
        return this.clienteForm.get('nome')!;
      }

      get clienteId(){
        return this.clienteForm.get('clienteId')!;
      }

      submit(){
        if(this.clienteForm.invalid){
          return;
        }
        console.log('Criado Formulário')
      }

      resetForm(event: any): void{
        event.preventDefault();
        this.clienteForm.reset();
      }


}
