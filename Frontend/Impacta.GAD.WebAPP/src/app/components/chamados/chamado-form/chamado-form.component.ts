import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Chamado } from 'src/app/models/Chamado';
import { ChamadoService } from 'src/app/services/chamado.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chamado-form',
  templateUrl: './chamado-form.component.html',
  styleUrls: ['./chamado-form.component.scss']
})
export class ChamadoFormComponent implements OnInit {
  
  chamado = {} as Chamado;
  chamadoForm!:  FormGroup;
  router: Router;
  
  
  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private chamadoService: ChamadoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router: Router    )
    {
      this.localeService.use('pt-br');
      this.router = router;
      
    }
    
    public salvar(): void{
      this.spinner.show();
      
      
      this.chamado = {... this.chamadoForm.value};
      
      this.chamado.id = 0;
      
      this.chamadoService.post(this.chamado).subscribe(
        () => this.toastr.success("Chamado salvo com sucesso!", "Sucesso")
                         .onHidden.subscribe(() => {setTimeout(window.location.href ='/chamados/lista', 2000)}),
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error("Erro ao salvar Chamado", "Erro");
        },
        () => this.spinner.hide()
        );
        
      }
      
      ngOnInit(): void {
        this.chamadoForm = new FormGroup({
          id: new FormControl(''),
          numero: new FormControl('',[Validators.required]),
          dataRecebimento: new FormControl('',[Validators.required]),
          dnsId: new FormControl('',[Validators.required]),
          bancoDadosId: new FormControl('',[Validators.required]),
          clienteId: new FormControl('',[Validators.required]),
          dataEnvioHomologacao: new FormControl(''),
          dataPublicacao: new FormControl(''),
          observacao: new FormControl(''),
          scriptText: new FormControl(''),
        });
      }
      
      get numero(){
        return this.chamadoForm.get('numero')!;
      }
      
      get dataRecebimento(){
        return this.chamadoForm.get('dataRecebimento')!
      }
      
      get dnsId(){
        return this.chamadoForm.get('dnsId')!;
      }
      
      get bancoDadosId(){
        return this.chamadoForm.get('bancoDadosId')!;
      }
      
      get clienteId(){
        return this.chamadoForm.get('clienteId')!;
      }
      
      get dataEnvioHomologacao(){
        return this.chamadoForm.get('dataEnvioHomologacao')!;
      }
      
      get dataPublicacao(){
        return this.chamadoForm.get('dataPublicacao')!;
      }
      
      get observacao(){
        return this.chamadoForm.get('observacao')!;
      }
      
      get scriptText(){
        return this.chamadoForm.get('scriptText')!;
      }
      
      
      
      
      submit(){
        if(this.chamadoForm.invalid){
          return;
        }
        console.log('Criado Formulário')
      }
      
      resetForm(event: any): void{
        event.preventDefault();
        this.chamadoForm.reset();
      }
      
      get bsConfig(): any{
        return {
          adaptivePosition: true,
          dateInputFormat: 'DD/MM/YYYY',
          containerClass: 'theme-orange',
          showWeekNumbers: false
        }
      }
      
    }
    