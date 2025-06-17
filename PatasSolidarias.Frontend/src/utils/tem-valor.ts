export function temValor<TValor>(valor: TValor): valor is NonNullable<TValor> {
  const retorno = valor !== null && valor !== undefined && valor !== '';
  return retorno;
}
