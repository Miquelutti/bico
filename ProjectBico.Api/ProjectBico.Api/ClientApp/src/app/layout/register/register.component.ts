import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AccountService } from 'src/app/core/services/account/account.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  form: FormGroup;
  loading = false;
  submitted = false;

  constructor(
      private formBuilder: FormBuilder,
      private route: ActivatedRoute,
      private toastr: ToastrService,
      private router: Router,
      private accountService: AccountService,
  ) {
      if (this.accountService.userValue) {
          this.router.navigate(['/home']);
      }
  }

  ngOnInit() {
      this.form = this.formBuilder.group({
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          email: ['', Validators.required],
          username: ['', Validators.required],
          password: ['', [Validators.required, Validators.minLength(6)]]
      });
  }

  get f() { return this.form.controls; }

  onSubmit() {
      this.submitted = true;
      if (this.form.invalid) {
          return;
      }

      this.loading = true;
      this.accountService.register(this.form.value)
          .pipe(first())
          .subscribe(
              data => {
                this.toastr.success('Usuário cadastrado com sucesso!', 'Sucesso', { timeOut: 3000 });
                  this.router.navigate(['../home'], { relativeTo: this.route });
              },
              error => {
                 this.toastr.error('Usuário já cadastrado!', 'Negado', { timeOut: 3000 });
                  this.loading = false;
              });
  }
}
