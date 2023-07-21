import { BancoDados } from "./BancoDados";
import { Cliente } from "./Cliente";
import { DNS } from "./DNS";

export interface Chamado {
  id: number;
  numero: string;
  isAtivo: boolean;
  dataHoraCadastro: Date;
  dataRecebimento: Date;
  dataEnvioHomologacao: Date;
  dataPublicacao: Date;
  observacao: string;
  scriptText: string;
  clienteId: number;
  cliente: Cliente;
  bancoDadosId: number;
  bancoDados: BancoDados;
  dnsId: number;
  dns: DNS;
}
