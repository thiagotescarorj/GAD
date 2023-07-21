import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidadorCampos } from 'src/app/helpers/ValidadorCampos';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  perfilForm!: FormGroup;

  constructor(private fb: FormBuilder){}

  formOptions: AbstractControlOptions = {
    validators: ValidadorCampos.ValidarCampos('senha', 'confirmarSenha')
  };

    ngOnInit(): void {
      this.perfilForm = this.fb.group({
        primeiroNome: ['', Validators.required],
        ultimoNome: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        senha: ['', [Validators.required, Validators.minLength(6)]],
        confirmarSenha: ['', Validators.required]
      }, this.formOptions);
  }

  get primeiroNome(){
    return this.perfilForm.get('primeiroNome')!;
  }

  get ultimoNome(){
    return this.perfilForm.get('ultimoNome')!
  }


  get email(){
    return this.perfilForm.get('email')!
  }

  get senha(){
    return this.perfilForm.get('senha')!
  }

  get confirmarSenha(){
    return this.perfilForm.get('confirmarSenha')!
  }

  submit(){
    if(this.perfilForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.perfilForm.reset();
  }

}

