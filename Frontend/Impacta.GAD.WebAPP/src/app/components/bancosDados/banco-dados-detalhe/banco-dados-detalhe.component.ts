import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BancoDados } from 'src/app/models/BancoDados';
import { BancoDadosService } from 'src/app/services/bancoDados.service';

@Component({
  selector: 'app-banco-dados-detalhe',
  templateUrl: './banco-dados-detalhe.component.html',
  styleUrls: ['./banco-dados-detalhe.component.scss']
})
export class BancoDadosDetalheComponent {

  public bancoDados = {} as BancoDados;


  constructor(
    private router: ActivatedRoute,
    private spinner: NgxSpinnerService,
    private bancoDadosService: BancoDadosService,
    private toastr: ToastrService,

  ){

  }

  public ngOnInit(): void{
    this.spinner.show();
    this.carregamenroBancoDados();
  }

  public carregamenroBancoDados(): void{

    const bancoDadosIdParam = this.router.snapshot.paramMap.get('id');

    if(bancoDadosIdParam != null){
      this.spinner.show();
      this.bancoDadosService.getBancoDadosById(+bancoDadosIdParam).subscribe(
        {
          next: (bancoDados: BancoDados) => {
            this.bancoDados = {...bancoDados};
            
          },
          error: () => {
            this.spinner.hide();
            this.toastr.error("Erro ao carregar o Banco de Dados.", "Erro!")
          },
          complete:  () => {
            this.spinner.hide();
          }
        }
      );
    }

  }

}
