export class Util {
  static nomeConcat(item: any[]) {
    return item.map(x => x.nome).join(',')  //pega o que enviar e retorna ele com uma ,
  }
}
