import { Cliente } from "./Cliente";

export interface BancoDados {
   id: number;
   nome: string;
   isAtivo: boolean;
   dataHoraCadastro: Date;
   clienteId: number;
   cliente: Cliente;
}
