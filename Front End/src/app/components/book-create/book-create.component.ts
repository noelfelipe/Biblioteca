import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { HttpProviderService } from '../../service/httpProvider/http-provider.service';

@Component({
  selector: 'book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.scss']
})
export class BookCreateComponent implements OnInit {
  bookCreate: BookForm = new BookForm(); // Update class name

  @ViewChild("bookForm")
  bookForm!: NgForm;

  isSubmitted: boolean = false;

  constructor(private router: Router, private httpProvider: HttpProviderService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  BookCreate(isValid: any) {
    this.isSubmitted = true;
    if (isValid) {
      this.httpProvider.saveBook(this.bookCreate).subscribe(
        async (data: any) => {
          if (data != null && data.body != null) {
            var resultData = data.body;
            if (resultData != null && resultData.isSuccess) {
              this.toastr.success(resultData.message);
              setTimeout(() => {
                this.router.navigate(['/Home']);
              }, 500);
            }
          }
        },
        async (error: any) => {
          // Use error.error.message to access the error message from the server
          this.toastr.error(error.error.errors.ISBN || 'An unexpected error occurred');
          setTimeout(() => { }, 500);
        }
      );
    }
  }
}

export class BookForm {
  Id: string = "";
  Titulo: string = "";
  Autor: string = "";
  DataPublicacao: string = "";
  ISBN: string = "";
}