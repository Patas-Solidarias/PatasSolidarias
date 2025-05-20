export class Field<T> {
  value: T | undefined;
  key: string;
  label: string;
  required: boolean;
  order: number;
  controlType?: FieldControlType;
  type?: FieldType;
  options: { key: string; value: T }[];
  constructor(
    options: {
      value?: T;
      key?: string;
      label?: string;
      required?: boolean;
      order?: number;
      controlType?: FieldControlType;
      type?: FieldType;
      options?: { key: string; value: T }[];
    } = {},
  ) {
    this.value = options.value;
    this.key = options.key || '';
    this.label = options.label || '';
    this.required = !!options.required;
    this.order = options.order === undefined ? 1 : options.order;
    this.controlType = options.controlType;
    this.type = options.type;
    this.options = options.options || [];
  }
}

export type FieldType =
  | 'input'
  | 'select'
  | 'checkbox'
  | 'radio'
  | 'textarea'
  | 'date'
  | 'file'
  | 'password'
  | 'email'
  | 'number'
  | 'tel'
  | 'url'
  | 'color'
  | 'range'
  | 'text'
  ;

export type FieldControlType =
  | 'input'
  | 'select'
  | 'checkbox'
  | 'radio'
  | 'textarea'
  | 'date'
  | 'file'
  | 'password'
  | 'email'
  | 'dropdown';
