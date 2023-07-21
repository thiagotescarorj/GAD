import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidadorCampos } from 'src/app/helpers/ValidadorCampos';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm!: FormGroup;

  constructor(private fb: FormBuilder){}

  formOptions: AbstractControlOptions = {
    validators: ValidadorCampos.ValidarCampos('senha', 'confirmarSenha')
  };

    ngOnInit(): void {
      this.registerForm = this.fb.group({
        primeiroNome: ['', Validators.required],
        ultimoNome: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        senha: ['', [Validators.required, Validators.minLength(6)]],
        confirmarSenha: ['', Validators.required]
      }, this.formOptions);
  }

  get primeiroNome(){
    return this.registerForm.get('primeiroNome')!;
  }

  get ultimoNome(){
    return this.registerForm.get('ultimoNome')!
  }


  get email(){
    return this.registerForm.get('email')!
  }

  get senha(){
    return this.registerForm.get('senha')!
  }

  get confirmarSenha(){
    return this.registerForm.get('confirmarSenha')!
  }

  submit(){
    if(this.registerForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.registerForm.reset();
  }

}
