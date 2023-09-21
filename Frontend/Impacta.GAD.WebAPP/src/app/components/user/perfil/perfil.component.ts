import { UserUpdate } from './../../../models/identity/UserUpdate';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/services/account.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidadorCampos } from 'src/app/helpers/ValidadorCampos';
import { Router } from '@angular/router';
import { ValidatorField } from 'src/app/helpers/ValidatorField';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {

  public usuario = {} as UserUpdate;
  public file: File;
  public imagemURL = '';


  constructor(
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private accountService: AccountService
  ) {}


  ngOnInit(): void {

  }

  public setFormValue(usuario: UserUpdate): void {
    this.usuario = usuario;
    // if (this.usuario.imagemURL)
    //   this.imagemURL = environment.apiURL + `resources/perfil/${this.usuario.imagemURL}`;
    // else
    //   this.imagemURL = './assets/img/perfil.png';

  }

  onFileChange(ev: any): void {
    const reader = new FileReader();

    reader.onload = (event: any) => this.imagemURL = event.target.result;

    this.file = ev.target.files;
    reader.readAsDataURL(this.file[0]);

   // this.uploadImagem();
  }

  // private uploadImagem(): void {
  //   this.spinner.show();
  //   this.accountService
    //  .postUpload(this.file)
      //.subscribe(
      //   () => this.toastr.success('Imagem atualizada com Sucesso', 'Sucesso!'),
      //   (error: any) => {
      //     this.toastr.error('Erro ao fazer upload de imagem','Erro!');
      //     console.error(error);
      //   }
      // ).add(() => this.spinner.hide());
 // }









}

