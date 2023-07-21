import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BancoDados } from 'src/app/models/BancoDados';
import { BancoDadosService } from 'src/app/services/bancoDados.service';

@Component({
  selector: 'app-banco-dados-editar',
  templateUrl: './banco-dados-editar.component.html',
  styleUrls: ['./banco-dados-editar.component.scss']
})
export class BancoDadosEditarComponent {

  bancoDados = {} as BancoDados;
  bancoDadosEditarForm!: FormGroup;
  router2: Router;
  
  
  constructor(private fb: FormBuilder,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private bancoDadosService: BancoDadosService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    router2: Router)
    {
      this.localeService.use('pt-br');
      this.router2 = router2;
      
    }
    
    public salvar(): void{
      this.spinner.show();
      
      
      this.bancoDados = {... this.bancoDadosEditarForm.value};
      
      
      this.bancoDadosService.put(this.bancoDados.id, this.bancoDados).subscribe(
        () => this.toastr.success("Banco de Dados salvo com sucesso!", "Sucesso")
                         .onHidden.subscribe(() => {setTimeout(window.location.href ='/bancoDados/lista', 2000)}),
        (error: any) => {
          console.log(error);
          this.spinner.hide();
          this.toastr.error("Erro ao salvar BancoDados", "Erro");
        },
        () => this.spinner.hide()
        );
        
      }
      
      
      public carregamentoBancoDados(): void{
        const bancoDadosIdParam = this.router.snapshot.paramMap.get('id');
        
        if(bancoDadosIdParam != null){
          this.spinner.show();
          this.bancoDadosService.getBancoDadosById(+bancoDadosIdParam).subscribe(
            {
              next: (bancoDados: BancoDados) => {
                this.bancoDados = {...bancoDados};
                this.bancoDadosEditarForm.patchValue(this.bancoDados);
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
          this.carregamentoBancoDados();
          this.bancoDadosEditarForm = new FormGroup({
            id: new FormControl(''),
            nome: new FormControl('',[Validators.required]),            
            clienteId: new FormControl('',[Validators.required]), 
            isAtivo: new FormControl('',[Validators.required]),                        
          });
        }
        
        get nome(){
          return this.bancoDadosEditarForm.get('nome')!;
        }
        
        get clienteId(){
          return this.bancoDadosEditarForm.get('clienteId')!;
        }

        get isAtivo(){
          return this.bancoDadosEditarForm.get('isAtivo')!;
        }
        
        
        submit(){
          if(this.bancoDadosEditarForm.invalid){
            return;
          }
          console.log('Atualizado Formulário')
        }
        
        resetForm(event: any): void{
          event.preventDefault();
          this.bancoDadosEditarForm.reset();
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
