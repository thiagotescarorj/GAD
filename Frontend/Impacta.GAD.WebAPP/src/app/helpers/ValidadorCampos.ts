import { group } from "@angular/animations";
import { AbstractControl, FormControlName, FormGroup } from "@angular/forms";

export class ValidadorCampos {

  static ValidarCampos(primeiroCampo: string, segundoCampo: string): any{
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const controle = formGroup.controls[primeiroCampo]
      const valicacaoControle = formGroup.controls[segundoCampo];


      if(valicacaoControle.errors && !valicacaoControle.errors['informacaoDiferente']){
        return null;
      }

      if(controle.value != valicacaoControle.value){
        valicacaoControle.setErrors({informacaoDiferente: true})
      }else{
        valicacaoControle.setErrors(null);
      }

      return null;
    };
  }

}
