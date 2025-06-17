export abstract class FieldBase<TModel> {
  abstract controlType: ControlType;
  placeholder?: string;
  disabled?: boolean;
  label?: string;
  labelSize?: number = 4;
  colSize?: number = 8;
  labelPlacement?: 'left' | 'top' | undefined = 'top';
  name!: keyof TModel | string;
  required?: boolean = false;
  default?: unknown;
}

export class FieldSelectBox<TModel> extends FieldBase<TModel> {
  controlType: 'select' = 'select';
  options!: { key: any; description: string }[];
}

export class FieldTextBox<TModel> extends FieldBase<TModel> {
  controlType: 'text' = 'text';
  password?: boolean;
  maxLength?: number;
}

export class FormFooterButtons<TModel> extends FieldBase<TModel> {
  controlType: 'form footer buttons' = 'form footer buttons';
  submitButtonText?: string = 'Salvar';
  cancelButtonText?: string = 'Cancelar';
}

export type Field<TModel> =
  | FieldSelectBox<TModel>
  | FieldTextBox<TModel>
  | FormFooterButtons<TModel>;

export type ControlType =
  | 'input'
  | 'select'
  | 'checkbox'
  | 'radio'
  | 'textarea'
  | 'date'
  | 'file'
  | 'email'
  | 'number'
  | 'tel'
  | 'url'
  | 'color'
  | 'range'
  | 'text'
  | 'form footer buttons'
  ;
