import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Chamado } from 'src/app/models/Chamado';
import { ChamadoService } from 'src/app/services/chamado.service';



@Component({
  selector: 'app-chamado-detalhe',
  templateUrl: './chamado-detalhe.component.html',
  styleUrls: ['./chamado-detalhe.component.scss']

})
export class ChamadoDetalheComponent {

  public chamado = {} as Chamado;


  constructor(
    private router: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private chamadoService: ChamadoService,
    private toastr: ToastrService,

  ){

  }

  public ngOnInit(): void{
    this.spinner.show();
    this.carregamenroChamado();
  }

  public carregamenroChamado(): void{

    const chamadoIdParam = this.router.snapshot.paramMap.get('id');

    if(chamadoIdParam != null){
      this.spinner.show();
      this.chamadoService.getChamadoById(+chamadoIdParam).subscribe(
        {
          next: (chamado: Chamado) => {
            this.chamado = {...chamado};
            
          },
          error: () => {
            this.spinner.hide();
            this.toastr.error("Erro ao carregar o Chamado.", "Erro!")
          },
          complete:  () => {
            this.spinner.hide();
          }
        }
      );
    }

  }

}
