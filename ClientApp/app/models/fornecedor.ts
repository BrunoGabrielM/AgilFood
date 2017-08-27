export interface Item {
    itemId: number;
    nome: string;
    descricao: string;
    codigo: string;
    preco: number;
  }
  
  export interface SavePedido {
    pedidoId: number; 
    nomeUsuario: string;
    emailUsuario: string;
    itens: number[];
  }
  
  export interface Pedido {
    pedidoId: number; 
    nomeUsuario: string;
    emailUsuario: string;
    itens: Item[];
  }