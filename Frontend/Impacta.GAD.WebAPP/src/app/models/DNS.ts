import { Cliente } from "./Cliente";

export interface DNS {
   id: number;
   nome: string;
   isAtivo: boolean;
   isAtividade: boolean;
   dataHoraCadastro: Date;
   clienteId: null;
   cliente: Cliente;
}
