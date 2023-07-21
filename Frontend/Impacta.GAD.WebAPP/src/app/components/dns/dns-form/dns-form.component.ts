import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-dns-form',
  templateUrl: './dns-form.component.html',
  styleUrls: ['./dns-form.component.scss']
})
export class DnsFormComponent implements OnInit {
  dnsForm!: FormGroup;

  constructor(private fb: FormBuilder){}

    ngOnInit(): void {
    this.dnsForm = new FormGroup({
            id: new FormControl(''),
            nome: new FormControl('', Validators.required),
            cliente: new FormControl('', Validators.required),

      });
  }

  get nome(){
    return this.dnsForm.get('nome')!;
  }

  get cliente(){
    return this.dnsForm.get('cliente')!
  }

  submit(){
    if(this.dnsForm.invalid){
      return;
    }
    console.log('Criado Formulário')
  }

   resetForm(event: any): void{
    event.preventDefault();
    this.dnsForm.reset();
  }

}
