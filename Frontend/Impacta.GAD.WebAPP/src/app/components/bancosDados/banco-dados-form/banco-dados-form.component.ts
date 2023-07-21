import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BancoDados } from 'src/app/models/BancoDados';
import { BancoDadosService } from 'src/app/services/bancoDados.service';

@Component({
  selector: 'app-banco-dados-form',
  templateUrl: './banco-dados-form.component.html',
  styleUrls: ['./banco-dados-form.component.scss']
})
export class BancoDadosFormComponent implements OnInit {

  bancoDados = {} as BancoDados;
  bancoDadosForm!: FormGroup;
  router: Router;

  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private bancoDadosService: BancoDadosService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router: Router){
      this.localeService.use('pt-br');
      this.router = router;
    }

    public salvar(): void{
      this.spinner.show();


      this.bancoDados = {... this.bancoDadosForm.value};

      this.bancoDados.id = 0;

      this.bancoDadosService.post(this.bancoDados).subscribe(
        () => {
          this.toastr.success("Banco de Dados salvo com sucesso!", "Sucesso")
                     .onHidden.subscribe(() => {setTimeout(window.location.href ='/bancoDados/lista', 2000);})

        },
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error("Erro ao salvar Banco de Dados", "Erro");
        },
        () => this.spinner.hide()
        );


      }

      ngOnInit(): void {
        this.bancoDadosForm = new FormGroup({
          id: new FormControl(''),
          nome: new FormControl('', Validators.required),
          clienteId: new FormControl('', Validators.required),

        });
      }

      get nome(){
        return this.bancoDadosForm.get('nome')!;
      }

      get clienteId(){
        return this.bancoDadosForm.get('clienteId')!;
      }

      submit(){
        if(this.bancoDadosForm.invalid){
          return;
        }
        console.log('Criado Formulário')
      }

      resetForm(event: any): void{
        event.preventDefault();
        this.bancoDadosForm.reset();
      }


    }
