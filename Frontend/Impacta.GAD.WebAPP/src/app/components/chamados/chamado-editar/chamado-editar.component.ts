import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Chamado } from 'src/app/models/Chamado';
import { ChamadoService } from 'src/app/services/chamado.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-chamado-editar',
  templateUrl: './chamado-editar.component.html',
  styleUrls: ['./chamado-editar.component.scss']
})
export class ChamadoEditarComponent implements OnInit {
  
  chamado = {} as Chamado;
  chamadoEditarForm!: FormGroup;
  router2: Router;
  
  
  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private chamadoService: ChamadoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router2: Router)
    {
      this.localeService.use('pt-br');
      this.router2 = router2;
      
    }
    
    public salvar(): void{
      this.spinner.show();
      
      
      this.chamado = {... this.chamadoEditarForm.value};
      
      
      this.chamadoService.put(this.chamado.id, this.chamado).subscribe(
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
      
      
      public carregamentoChamado(): void{
        const chamadoIdParam = this.router.snapshot.paramMap.get('id');
        
        if(chamadoIdParam != null){
          this.spinner.show();
          this.chamadoService.getChamadoById(+chamadoIdParam).subscribe(
            {
              next: (chamado: Chamado) => {
                this.chamado = {...chamado};
                this.chamadoEditarForm.patchValue(this.chamado);
              },
              error: () => {
                this.spinner.hide();
                this.toastr.error("Erro ao carregar o Chamado.", "Erro!")
              },
              complete:  () => {
                this.spinner.hide();
              }
            });
          }
          
        }
        
        ngOnInit(): void {
          this.carregamentoChamado();
          this.chamadoEditarForm = new FormGroup({
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
          return this.chamadoEditarForm.get('numero')!;
        }
        
        get clienteId(){
          return this.chamadoEditarForm.get('clienteId')!;
        }
        
        get dnsId(){
          return this.chamadoEditarForm.get('dnsId')!;
        }
        
        get bancoDadosId(){
          return this.chamadoEditarForm.get('bancoDadosId')!;
        }
        
        get dataRecebimento(){
          return this.chamadoEditarForm.get('dataRecebimento')!;
        }
        
        get dataEnvioHomologacao(){
          return this.chamadoEditarForm.get('dataEnvioHomologacao')!;
        }
        
        get dataPublicacao(){
          return this.chamadoEditarForm.get('dataPublicacao')!;
        }
        
        get observacao(){
          return this.chamadoEditarForm.get('observacao')!;
        }
        
        get scriptText(){
          return this.chamadoEditarForm.get('scriptText')!;
        }
        
        submit(){
          if(this.chamadoEditarForm.invalid){
            return;
          }
          console.log('Atualizado Formulário')
        }
        
        resetForm(event: any): void{
          event.preventDefault();
          this.chamadoEditarForm.reset();
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
      
      