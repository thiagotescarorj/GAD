import { BancoDados } from "./BancoDados";
import { Chamado } from "./Chamado";
import { DNS } from "./DNS";

export interface Cliente {
  id: number;
  nome: string;
  isAtivo: boolean;
  dataHoraCadastro: Date;
  chamado?: Chamado[];
  dNS?: DNS[];
  bancoDados?: BancoDados[];
}
