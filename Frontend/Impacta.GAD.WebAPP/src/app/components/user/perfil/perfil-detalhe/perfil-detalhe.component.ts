import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { ValidatorField } from 'src/app/helpers/ValidatorField';
import { UserUpdate } from 'src/app/models/identity/UserUpdate';
import { AccountService } from 'src/app/services/account.service';


@Component({
  selector: 'app-perfil-detalhe',
  templateUrl: './perfil-detalhe.component.html',
  styleUrls: ['./perfil-detalhe.component.css']
})
export class PerfilDetalheComponent implements OnInit {

  @Output() changeFormValue = new EventEmitter();

  usuario = {} as UserUpdate;

  perfilForm!: FormGroup;


  constructor(private fb: FormBuilder,
    public accountService: AccountService,
    private router: Router,
    private toaster: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.validation();
    this.carregarUsuario();
    this.verificaForm();
  }

  private verificaForm(): void {
    this.perfilForm.valueChanges
      .subscribe(() => this.changeFormValue.emit({...this.perfilForm.value}))
  }
  private carregarUsuario(): void {
    this.spinner.show();
    this.accountService
      .getUser()
      .subscribe(
        (userRetorno: UserUpdate) => {
          console.log(userRetorno);
          this.usuario = userRetorno;
          this.perfilForm.patchValue(this.usuario);
          this.toaster.success('Usuário Carregado', 'Sucesso');
        },
        (error) => {
          console.error(error);
          this.toaster.error('Usuário não Carregado', 'Erro');
          this.router.navigate(['/dashboard']);
        }
      )
      .add(() => this.spinner.hide());
  }
  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMatch('password', 'confirmarPassword')
    };
       this.perfilForm = this.fb.group({
         userName:[''],
         nome: ['', Validators.nullValidator],
         sobrenome: ['', Validators.nullValidator],
         perfilUsuario: ['NaoInformado', Validators.nullValidator],
         email: ['', [Validators.nullValidator, Validators.email]],
         password: ['', [Validators.minLength(6),Validators.nullValidator]],
         confirmarPassword: ['', Validators.nullValidator]
       },
       formOptions)
       ;

    }

    get form(): any {
      return this.perfilForm.controls;
    }

    onSubmit(): void {
      this.atualizarUsuario();
    }

    public atualizarUsuario() {
      this.usuario = { ...this.perfilForm.value };
      this.spinner.show();

      // if (this.form.funcao.value == 'Palestrante') {
      //   this.palestranteService.post().subscribe(
      //     () => this.toaster.success('Função palestrante Ativada!', 'Sucesso!'),
      //     (error) => {
      //       this.toaster.error('A função palestrante não pode ser Ativada', 'Error');
      //       console.error(error);
      //     }
      //   )
      // }

      this.accountService
        .updateUser(this.usuario)
        .subscribe(
          () => this.toaster.success('Usuário atualizado!', 'Sucesso'),
          (error) => {
            this.toaster.error(error.error);
            console.error(error);
          }
        )
        .add(() => this.spinner.hide());
    }

    public resetForm(event: any): void {
      event.preventDefault();
      this.perfilForm.reset();
    }

}
