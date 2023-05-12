import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-salarycalculate',
  templateUrl: './salary-calculate.component.html',
  styleUrls: ['./salary-calculate.component.css']
})

export class SalaryCalculateComponent implements OnInit {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private fb: FormBuilder) {
  }

  public salarySlipInformation = "";
  public parentForm!: FormGroup;

  monthsList = [
    { name: 'January', value: 'January' },
    { name: 'February', value: 'February' },
    { name: 'March', value: 'March' },
    { name: 'April', value: 'April' },
    { name: 'May', value: 'May' },
    { name: 'June', value: 'June' },
    { name: 'July', value: 'July' },
    { name: 'August', value: 'August' },
    { name: 'September', value: 'September' },
    { name: 'October', value: 'October' },
    { name: 'November', value: 'November' },
    { name: 'December', value: 'December' }];
    
  ngOnInit(): void {
    this.buildForm();
  }

  buildForm() {
    this.parentForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      annualSalary: [0.0, Validators.required],
      supperRate: [0.0, Validators.required],
      payPeriod: ['', Validators.required],
    });
  }

  save() {
    if (this.parentForm.valid) {
      const model = this.parentForm.getRawValue();

      this.http.post<any>(this.baseUrl + 'salarycalculate', model).subscribe(result => {
        debugger;
        this.salarySlipInformation = result;
      }, error => console.error(error));

      debugger;

    } else {
      this.formValidation(this.parentForm);
    }
  }

  formValidation(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach((control: FormGroup) => {
      control.markAsTouched();
      control.updateValueAndValidity();
      if (control.controls) { this.formValidation(control); }
    });
  }
}
