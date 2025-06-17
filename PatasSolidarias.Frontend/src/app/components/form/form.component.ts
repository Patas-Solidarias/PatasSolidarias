import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from "@angular/forms";
import { ButtonModule } from "primeng/button";
import { DialogModule } from "primeng/dialog";
import { DropdownModule } from "primeng/dropdown";
import { InputTextModule } from "primeng/inputtext";
import { TableModule } from "primeng/table";

import { Field } from "./form.types";

@Component({
  selector: "app-form",
  imports: [
    CommonModule,
    FormsModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    DropdownModule,
    ReactiveFormsModule,
  ],
  template: `
    <form
      [formGroup]="formGroup"
      (ngSubmit)="submit()"
      *ngIf="fields?.length && formGroup"
      class="space-y-6"
    >
      <div class="w-full flex flex-col gap-2">
          @for (item of fields; track item.name) { @if (item.label) {
          <label
            [attr.for]="item.name"
            class="mb-1 font-medium text-left"
          >
              {{ item.label }}
              {{ item.required === true ? ' (obrigatório)' : '' }}
          </label>
          }
            @switch (item.controlType) { @case('text') {
            <input
              [formControlName]="item.name.toString()"
              [id]="item.name"
              [type]="item.password ? 'password' : 'text'"
              class="p-inputtext p-component rounded-md focus:ring-2 focus:ring-blue-500 w-full"
              pInputText
            />
            } @case ('select') {
            <p-dropdown
              [formControlName]="item.name.toString()"
              [options]="item.options"
              optionLabel="description"
              optionValue="key"
              class="w-full"
            />
            } @case ('form footer buttons') {
            <footer class="flex justify-end gap-2 mt-4 w-full">
              <button
                type="submit"
                pButton
                [label]="
                  item.submitButtonText || formGroup.dirty
                    ? 'Salvar'
                    : 'Adicionar'
                "
                icon="pi pi-check"
                class="p-button-success hover:scale-105 transition-transform bg-[#87BFA8]"
              ></button>
              <button
                type="button"
                pButton
                [label]="item.cancelButtonText || 'Cancelar'"
                icon="pi pi-times"
                (click)="this.onCancel.emit()"
                class="p-button-secondary hover:scale-105 transition-transform"
              ></button>
            </footer>
            } }
          }
        </div>
    </form>
  `,
})
export class FormComponent<TModel> implements OnInit {
  @Input() public fields: Field<TModel>[] = [];
  @Output() onSubmit = new EventEmitter<TModel>();
  @Output() onCancel = new EventEmitter<void>();

  public formGroup?: FormGroup;

  public submit() {
    if (!this.formGroup) {
      throw new Error("Formulário não inicializado.");
    }

    const command = this.formGroup.value as TModel;
    this.onSubmit.emit(command);
  }

  ngOnInit(): void {
    if (!this.fields || this.fields.length === 0) {
      throw new Error("Campos não definidos.");
    }
    this.formGroup = this.getFormGroupFromFields();
  }

  obterValorFormulario(): TModel | null {
    if (!this.formGroup) {
      return null;
    }

    if (this.formGroup.invalid) {
      return null;
    }

    return this.formGroup.value as TModel;
  }

  private getFormGroupFromFields() {
    const formBuilder = new FormBuilder().nonNullable;
    const retorno = formBuilder.group({});

    if (!this.fields || this.fields.length === 0) {
      return retorno;
    }

    this.fields.forEach((campo) => {
      const controlName = campo.name.toString();
      const newControl = formBuilder.control(
        campo.default,
        campo.required ? Validators.required : undefined,
      );

      retorno.addControl(controlName, newControl);
    });

    return retorno;
  }
}
