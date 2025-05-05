export enum EUsuarioTipo {
  Doador = 0,
  EmpresaParceira = 1,
  Ong = 2,
}

export const usuarioTipos: { label: string; value: number }[] = [
  { label: "Doador", value: EUsuarioTipo.Doador },
  { label: "Empresa parceira", value: EUsuarioTipo.EmpresaParceira },
  { label: "Ong", value: EUsuarioTipo.Ong },
];
